using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using BurgerToNightFunc.Services.IServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

public class UpdateProduct
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBlobService _blobService;
    private readonly IUserRepo _userRepo;

    public UpdateProduct(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _blobService = blobService;
        _userRepo = userRepo;
    }
    [Authorize(roles:"admin")]
    [Function("UpdateProduct")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "productAPI/{id}")] HttpRequestData req,
        FunctionContext context,
        int id)
    {
        var log = context.GetLogger("UpdateProduct");
        var response = new APIResponse();

        try
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDTO = JsonConvert.DeserializeObject<BProductUpdateDTO>(requestBody);

            if (updateDTO == null || id != updateDTO.Id)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Invalid input");
                return response;
            }

            var existingProduct = await _unitOfWork.BProducts.GetAsync(u=>u.Id==id);
            if (existingProduct == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Product not found");
                return response;
            }

            // Update product properties
            _mapper.Map(updateDTO, existingProduct);
            await _unitOfWork.BProducts.UpdateAsync(existingProduct);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<BProductGetDTO>(existingProduct);
            result.burgerCategory = (await _unitOfWork.BCategories.GetAsync(c => c.Id == existingProduct.BCategoryId))?.Name;

            response.StatusCode = HttpStatusCode.OK;
            response.Result = result;
        }
        catch (Exception ex)
        {
            log.LogError($"Error updating product: {ex.Message}");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }

}
