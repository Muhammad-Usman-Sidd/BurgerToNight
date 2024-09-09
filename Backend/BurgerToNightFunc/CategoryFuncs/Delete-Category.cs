using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class DeleteCategory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepo _userRepo;

    public DeleteCategory(IUnitOfWork unitOfWork, IUserRepo userRepo)
    {
        _unitOfWork = unitOfWork;
        _userRepo = userRepo;
    }
    [Authorize(roles: "admin")]
    [Function("DeleteCategory")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "categoryAPI/{id}")] HttpRequestData req,
        FunctionContext context,
        int id)
    {
        var log = context.GetLogger("DeleteCategory");
        var response = new APIResponse();

        try
        {

            var existingCategory = await _unitOfWork.Categories.GetAsync(u => u.Id == id);
            if (existingCategory == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Category not found");
                return response;
            }

            await _unitOfWork.Categories.RemoveAsync(existingCategory);
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
