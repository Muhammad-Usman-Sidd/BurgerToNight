using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using BurgerToNightFunc.Services.IServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;
public class CreateProduct
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly IBlobService _blobService;

    public CreateProduct(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _blobService = blobService;
        _userRepo = userRepo;
    }
    [Authorize(roles: "admin")]
    [Function("CreateProduct")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "productAPI")] HttpRequestData req)
    {
        var response = new APIResponse();

        try
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createDTO = JsonConvert.DeserializeObject<ProductPostDTO>(requestBody);

            if (createDTO == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Invalid input");
                return response;
            }

            if (await _unitOfWork.Products.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Product already exists");
                return response;
            }

            if (await _unitOfWork.Categories.GetAsync(u => u.Id == createDTO.CategoryId) == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Invalid category ID");
                return response;
            }

            var blobName = await _blobService.UploadBase64ImageAsync(createDTO.Image);
            var product = _mapper.Map<Product>(createDTO);
            product.Image = blobName;

            await _unitOfWork.Products.CreateAsync(product);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<ProductGetDTO>(product);
            result.productCategory = (await _unitOfWork.Categories.GetAsync(c => c.Id == product.CategoryId))?.Name;

            response.StatusCode = HttpStatusCode.Created;
            response.Result = result;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }
}
