using AutoMapper;
using BurgerToNight.Utility;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Diagnostics;

namespace BurgerToNightUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public HomeController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<List<BProductDTO>>(Convert.ToString(response.Result));
                foreach (var product in data)
                {
                    if (product.Image != null)
                    {
                        var type = "image";
                        if (product.Image.StartsWith("/9j/4AAQ"))
                        {
                            type = "image/jpeg";
                        }
                        else if (product.Image.StartsWith("iVBORw0KGgo"))
                        {
                            type = "image/png";
                        }
                        product.ExistingImage = product.Image;
                        product.ExistingImageType = type;
                    }
                }
                return View(data);
            }
            return View();
        }

    }
}