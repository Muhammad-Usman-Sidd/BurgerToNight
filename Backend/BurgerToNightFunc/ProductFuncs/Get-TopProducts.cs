using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class GetTopSellingProducts
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepo _userRepo;

    public GetTopSellingProducts(IUnitOfWork unitOfWork, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _userRepo = userRepo;
    }

    [Function("GetTopSellingProducts")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "productAPI/top-products/{topCount}")] HttpRequestData req,
        FunctionContext context,
        int topCount)
    {
        var log = context.GetLogger("GetTopSellingProducts");
        var response = new APIResponse();

        try
        {
            var topProduct = await _unitOfWork.Products.GetTopSellingProducts(topCount); 

            response.Result = topProduct;
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            log.LogError($"Error retrieving top products: {ex.Message}");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }
}
