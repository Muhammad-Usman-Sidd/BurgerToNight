using AutoMapper;
using BurgerToNight.Utility;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace BurgerToNightUI.Controllers
{
    public class BCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public BCategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet(Name ="IndexCategory")]
        public async Task<IActionResult> IndexCategory()
        {
            List<BCategoryDTO> list = new();

            var response = await _categoryService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BCategoryDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost(Name = "CreateCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(BCategoryCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var response = await _categoryService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {

                BCategoryDTO model = JsonConvert.DeserializeObject<BCategoryDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<BCategoryUpdateDTO>(model));
            }
            return NotFound();
        }
        [HttpPost(Name ="UpdateCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(BCategoryUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category updated successfully";
                var response = await _categoryService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var response = await _categoryService.GetAsync<APIResponse>(Id);
            if (response != null && response.IsSuccess)
            {
                BCategoryDTO model = JsonConvert.DeserializeObject<BCategoryDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
  
        [HttpPost(Name ="DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(BCategoryDTO model)
        {

            var response = await _categoryService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction(nameof(IndexCategory));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

    }
}
