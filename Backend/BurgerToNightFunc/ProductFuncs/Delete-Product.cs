using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class DeleteProduct
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepo _userRepo;

    public DeleteProduct(IUnitOfWork unitOfWork, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _userRepo = userRepo;
    }
    [Authorize(roles: "admin")]
    [Function("DeleteProduct")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "productAPI/{id}")] HttpRequestData req,
        FunctionContext context,
        int id)
    {
        var log = context.GetLogger("DeleteProduct");
        var response = new APIResponse();

        try
        {

            var existingProduct = await _unitOfWork.Products.GetAsync(u => u.Id == id);
            if (existingProduct == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Product not found");
                return response;
            }

            await _unitOfWork.Products.RemoveAsync(existingProduct);
            await _unitOfWork.SaveAsync();

            response.StatusCode = HttpStatusCode.NoContent;
        }
        catch (Exception ex)
        {
            log.LogError($"Error deleting product: {ex.Message}");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }

}
