using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class GetAll_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public GetAll_Product(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        [Function("GetAllProduct")]
        public async Task<APIResponse> Run(
         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "productAPI")] HttpRequestData req,
         FunctionContext context)
        {
            var log = context.GetLogger("GetAllProduct");
            var response = new APIResponse();

            try
            {
                var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
                int pageNumber = int.TryParse(query["pageNumber"], out pageNumber) ? pageNumber : 1;
                int pageSize = int.TryParse(query["pageSize"], out pageSize) ? pageSize : 6;
                string searchQuery = query["searchQuery"] ?? string.Empty;

                var allCategories = await _unitOfWork.BCategories.GetAllAsync();
                var filteredCategories = allCategories
                    .Where(c => string.IsNullOrEmpty(searchQuery) ||
                                c.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.Id)
                    .ToList();

                var allProducts = await _unitOfWork.BProducts.GetAllAsync();

                var filteredProducts = allProducts
                    .Where(p => string.IsNullOrEmpty(searchQuery) ||
                                p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                filteredCategories.Contains(p.BCategoryId))
                    .ToList();

                if (filteredProducts == null || !filteredProducts.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add($"No products found for the search query: {searchQuery}");
                    return response;
                }

                var totalCount = filteredProducts.Count;

                var products = filteredProducts
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var productDTOs = new List<BProductGetDTO>();
                foreach (var item in products)
                {
                    var burgerCategory = await _unitOfWork.BCategories.GetAsync(c => c.Id == item.BCategoryId);
                    var mappedProduct = _mapper.Map<BProductGetDTO>(item);
                    mappedProduct.burgerCategory = burgerCategory?.Name ?? "Unknown"; // Handle null case

                    if (!string.IsNullOrEmpty(item.Image) && item.Image.StartsWith("Blob"))
                    {
                        try
                        {
                            mappedProduct.Image = await _blobService.DownloadBlobAsBase64Async(item.Image);
                        }
                        catch (Exception ex)
                        {
                            log.LogError($"Error retrieving image for product {item.Id}: {ex.Message}");
                            mappedProduct.Image = "Error retrieving image";
                        }
                    }
                    productDTOs.Add(mappedProduct);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = new
                {
                    Products = productDTOs,
                    TotalCount = totalCount
                };
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
}