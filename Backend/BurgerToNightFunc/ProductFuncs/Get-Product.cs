using AutoMapper;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Services.IServices;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using BurgerToNightAPI.Repository;
using BurgerToNightFunc.Attributes;

public class Get_Product
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBlobService _blobService;
    private readonly IUserRepo _userRepo;

    public Get_Product(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _blobService = blobService;
        _userRepo = userRepo;
    }
    [Authorize(roles: ["admin","customer"])]
    [Function("GetProduct")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "productAPI/{id}")] HttpRequestData req,
        FunctionContext context, int id)
    {
        var log = context.GetLogger("GetProduct");
        var response = new APIResponse();

        try
        {
            var product = await _unitOfWork.Products.GetAsync(u => u.Id == id);
            if (product == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Product with id {id} not found.");
                return response;
            }


            var mappedProduct = _mapper.Map<ProductGetDTO>(product);
            var burgerCategory = await _unitOfWork.Categories.GetAsync(c => c.Id == mappedProduct.CategoryId);
            mappedProduct.burgerCategory = burgerCategory?.Name;

            if (!string.IsNullOrEmpty(product.Image) && product.Image.StartsWith("Blob"))
            {
                try
                {
                    mappedProduct.Image = await _blobService.DownloadBlobAsBase64Async(product.Image);
                }
                catch (Exception ex)
                {
                    log.LogError($"Error retrieving image for product {product.Id}: {ex.Message}");
                    mappedProduct.Image = "Error retrieving image";
                }
            }

            response.StatusCode = HttpStatusCode.OK;
            response.Result = mappedProduct;
        }
        catch (Exception ex)
        {
            log.LogError($"Error getting product with id {id}: {ex.Message}");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }
}
