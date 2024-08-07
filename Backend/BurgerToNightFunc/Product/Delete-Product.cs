using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class DeleteProduct
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProduct(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

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
            // Validate authentication
            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            if (token == null || !await IsUserAuthorized(token))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Unauthorized");
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

            await _unitOfWork.BProducts.RemoveAsync(existingProduct);
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

    private async Task<bool> IsUserAuthorized(string token)
    {
        // Implement authentication and authorization logic here
        return true; // Replace with actual logic
    }
}
