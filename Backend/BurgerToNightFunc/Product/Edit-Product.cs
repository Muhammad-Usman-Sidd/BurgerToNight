using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Services.IServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BurgerToNightFunc.Product
{
    public class Edit_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public Edit_Product(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        [Function("EditProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "ProductAPI/{id}")] HttpRequestData req,
            FunctionContext context, int id)
        {
            var log = context.GetLogger("EditProduct");
            var response = new APIResponse();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updateDTO = JsonConvert.DeserializeObject<BProductUpdateDTO>(requestBody);

                if (updateDTO == null || id != updateDTO.Id)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Error: ID mismatch or DTO is null.");
                    return response;
                }

                if (await _unitOfWork.BCategories.GetAsync(u => u.Id == updateDTO.BCategoryId) == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Error: BCategoryID mismatch or is null.");
                    return response;
                }

                var existingProduct = await _unitOfWork.BProducts.GetAsync(u => u.Id == id);

                if (existingProduct == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add($"Product with id {id} not found.");
                    return response;
                }

                if (!string.IsNullOrEmpty(updateDTO.Image) && updateDTO.Image.StartsWith("data:image"))
                {
                    var imageUrl = await _blobService.UploadBase64ImageAsync(updateDTO.Image);
                    updateDTO.Image = imageUrl;
                }
                else
                {
                    updateDTO.Image = existingProduct.Image;
                }

                var updatedProduct = _mapper.Map(updateDTO, existingProduct);

                await _unitOfWork.BProducts.UpdateAsync(updatedProduct);
                await _unitOfWork.SaveAsync();

                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                log.LogError($"Error updating product with id {id}: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
