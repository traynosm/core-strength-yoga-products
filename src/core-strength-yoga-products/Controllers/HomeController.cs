using core_strength_yoga_products.Exceptions;
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
        private readonly IProductTypeService _productTypeService;

        public HomeController(ILogger<HomeController> logger, IProductCategoryService productCategoryService, 
            IProductTypeService productTypeService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _productTypeService = productTypeService;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Set("setSession", new byte[] { 1 });
            var cart = JsonConvert.SerializeObject(new List<BasketItem>());

            HttpContext.Session.SetString("cart", cart);
            HttpContext.Session.SetString("cartTotal", "€0.00");
            var home = new Home();
            var categories = new List<ProductCategory>();
            var types = new List<ProductType>();
            try
            {
                var categoryResult = await GetCategories();
                var typeResult = await GetTypes();
      

                if (categoryResult != null)
                {
                    categories = (List<ProductCategory>) categoryResult;
                }
                else
                {
                    categories = null;
                }

                if (categoryResult != null)
                {
                    types = (List<ProductType>) typeResult;
                }
                else
                {
                    types = null;
                }

                home.productCategories = categories;
                home.productTypes = types;
                return View(home);
            }
            catch (ProductCategoryException pcex)
            {
                //throw; use this if want to display developer exception page
                return BadRequest($"{pcex.Message}, Please ensure the core-strength-yoga products-API is running");
            }
            catch (ProductTypeException ptex)
            {
                return BadRequest($"{ptex.Message}, Please ensure the core-strength-yoga products-API is running");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}, Please ensure the core-strength-yoga products-API is running");
            }
        }
        public async Task<IEnumerable<ProductCategory>?> GetCategories()
        {
            try
            {
                return await _productCategoryService.GetCategories();
            }
            catch (Exception ex)
            {
                throw new ProductCategoryException(ex);
            }
        }

        public async Task<IEnumerable<ProductType>?> GetTypes()
        {
            try
            {
                return await _productTypeService.GetTypes();
            }
            catch (Exception ex)
            {
                throw new ProductTypeException(ex);
            }
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