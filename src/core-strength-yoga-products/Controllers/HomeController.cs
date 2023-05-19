using core_strength_yoga_products.Interfaces;
using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using core_strength_yoga_products.Models.Dtos;
using core_strength_yoga_products.Services;

namespace core_strength_yoga_products.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        private readonly ProductCategoryService _productCategoryService;
        private readonly ProductTypeService _prodcuctTypeService;

        public HomeController(ILogger<HomeController> logger, ProductCategoryService productCategoryService, ProductTypeService productTypeService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _prodcuctTypeService = productTypeService;
        }

        public async Task<IActionResult> Index()
        {
            HomeDto homeDto = new HomeDto();
            var categories = _productCategoryService.GetCategories().Result;
            var types = _prodcuctTypeService.GetTypes().Result;

            homeDto.productCategories = categories;
            homeDto.productTypes = types;
            return View(homeDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}