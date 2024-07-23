using System;
using System.Net;
using System.Threading.Tasks;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Services.IServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BurgerToNightFunc.Product
{
    public class Delete_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobService _blobService;

        public Delete_Product(IUnitOfWork unitOfWork, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
        }

        [Function("DeleteProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "ProductAPI/{id}")] HttpRequestData req,
            FunctionContext context, int id)
        {
            var log = context.GetLogger("DeleteProduct");
            var response = new APIResponse();

            try
            {
                var product = await _unitOfWork.BProducts.GetAsync(u => u.Id == id);
                if (product == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add($"Product with id {id} not found.");
                    return response;
                }

                if (!string.IsNullOrEmpty(product.Image) && product.Image.StartsWith("Blob"))
                {
                    //var blobName = Path.GetFileName(new Uri(product.Image).AbsolutePath);
                    await _blobService.DeleteBlobAsync(product.Image);
                }

                await _unitOfWork.BProducts.RemoveAsync(product);
                await _unitOfWork.SaveAsync();

                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = null;
            }
            catch (Exception ex)
            {
                log.LogError($"Error deleting product with id {id}: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
