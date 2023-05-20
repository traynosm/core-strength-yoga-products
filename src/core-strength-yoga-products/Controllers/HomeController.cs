using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace core_strength_yoga_products.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
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
            var home = new Home();
            var categories = _productCategoryService.GetCategories().Result;
            var types = _prodcuctTypeService.GetTypes().Result;

            home.productCategories = categories;
            home.productTypes = types;
            return View(home);
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