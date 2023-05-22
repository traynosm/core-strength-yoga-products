using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace core_strength_yoga_products.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductTypeService _prodcuctTypeService;

        public HomeController(ILogger<HomeController> logger, IProductCategoryService productCategoryService, IProductTypeService productTypeService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _prodcuctTypeService = productTypeService;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Set("setSession", new byte[] { 1 });
            var cart = JsonConvert.SerializeObject(new List<BasketItem>());
            //{
            //    new BasketItem
            //    {
            //        ProductId = 1,
            //    }
            //});
            HttpContext.Session.SetString("cart", cart);
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