using AutoMapper;
using BurgerToNight.Models;
using BurgerToNight.Utility;
using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Models.VM;
using BurgerToNightUI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Data;
using APIResponse = BurgerToNightUI.Models.APIResponse;

namespace BurgerToNightUI.Controllers
{
    public class BProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        public BProductController(IProductService productService, IMapper mapper, ICategoryService categoryService,IWebHostEnvironment webHost)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _webHost = webHost;
        }
        public async Task<IActionResult> IndexProduct()
        {
            List<BProductDTO> list = new();

            var response = await _productService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BProductDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateProduct()
        {
            BProductCreateVM productVM = new();
            var response = await _categoryService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<BCategoryDTO>>
                (Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Title,
                    Value = i.Id.ToString()
                });
            }
            return View(productVM);
        }
        [HttpPost(Name ="CreateProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(BProductCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _productService.CreateAsync<APIResponse>(model.BProduct);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _categoryService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.CategoryList = JsonConvert.DeserializeObject<List<BCategoryDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Title,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            BProductUpdateVM productVM = new();
            var response = await _productService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                BProductDTO model = JsonConvert.DeserializeObject<BProductDTO>(Convert.ToString(response.Result));
                productVM.BProduct = _mapper.Map<BProductUpdateDTO>(model);
            }

            response = await _categoryService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<BCategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Title,
                        Value = i.Id.ToString()
                    });
                return View(productVM);
            }


            return NotFound();
        }
        [HttpPost(Name ="UpdateProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(BProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _productService.UpdateAsync<APIResponse>(model.BProduct);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _categoryService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.CategoryList = JsonConvert.DeserializeObject<List<BCategoryDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Title,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            BProductDeleteVM productVM = new();

            // fetch product details
            var response = await _productService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var productJson = Convert.ToString(response.Result);
                BProductDeleteDTO product = JsonConvert.DeserializeObject<BProductDeleteDTO>(productJson);
                productVM.BProduct =_mapper.Map<BProductDTO>(product);

                // checking if the product has a valid category id
                if (product != null && product.BCategoryId > 0)
                {
                    // fetch the category
                    var categoryResponse = await _categoryService.GetAsync<APIResponse>(product.BCategoryId);
                    if (categoryResponse != null && categoryResponse.IsSuccess)
                    {
                        var categoryJson = Convert.ToString(categoryResponse.Result);
                        BCategoryDTO category = JsonConvert.DeserializeObject<BCategoryDTO>(categoryJson);

                        if (category != null)
                        {
                            productVM.BProduct.burgerCategory = category; // assign category to product
                        }
                    }
                }
            }   // Return the view model to the view
          return View(productVM);
        }
        [HttpPost(Name ="DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(BProductDeleteVM productVM)
        {
            var response = await _productService.DeleteAsync<APIResponse>(productVM.BProduct.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexProduct));
            }
            return View(productVM);
        }



    }
}
