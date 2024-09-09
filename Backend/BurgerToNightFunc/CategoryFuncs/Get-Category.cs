using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;


public class Get_Category
{
    private readonly IUnitOfWork _unitOfWork;

    public Get_Category(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [Authorize(roles: "admin")]
    [Function("GetCategory")]
    public async Task<APIResponse> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "CategoryAPI/{id}")] HttpRequestData req,
                FunctionContext context, int id)
    {
        var log = context.GetLogger("GetCategory");
        var response = new APIResponse();

        try
        {
            var category = await _unitOfWork.Categories.GetAsync(u => u.Id == id);
            if (category == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"No Category found with id :{id}");
                return response;
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Result = category;
        }
        catch (Exception ex)
        {
            log.LogError($"Error getting products: {ex.Message}");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"Internal server error: {ex.Message}");
        }

        return response;
    }
}

