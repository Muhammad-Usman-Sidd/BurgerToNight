using System.Net;
using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


public class GetAll_Category
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAll_Category(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [Function("GetAllCategory")]
    public async Task<APIResponse> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "CategoryAPI")] HttpRequestData req,
                FunctionContext context)
    {
        var log = context.GetLogger("GetAllCategory");
        var response = new APIResponse();
        try
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if (categories == null || !categories.Any())
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add("No products found.");
                return response;
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Result = categories;
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

