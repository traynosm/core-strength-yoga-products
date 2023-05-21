using core_strength_yoga_products.Data;
using Microsoft.AspNetCore.Mvc;
using core_strength_yoga_products.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace core_strength_yoga_products.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly core_strength_yoga_productsContext  _dbContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;

        public ShopController(ILogger<ShopController> logger, core_strength_yoga_productsContext dbContext, IHttpClientFactory clientFactory, IProductCategoryService productCategoryService, IProductTypeService productTypeService, IProductService productService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _clientFactory = clientFactory;
            _productCategoryService = productCategoryService;
            _productTypeService = productTypeService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productCategoryService.GetCategories();
            return View(categories);
        }
        public async Task<IActionResult> ProductTypes(int productCategoryId)
        {
            var types = await _productTypeService.GetTypesByCategoryId(productCategoryId);
            return View(types);
        }
        public async Task<IActionResult> Gallery(int productTypeId)
        {
            var products = await _productService.GetProductsByTypeId(productTypeId);
            return View(products);
        }
        public async Task<IActionResult> Product(int productId)
        {
            var product = await _productService.GetProduct(productId);
            return View(product);
        }


        public async Task<IActionResult> Description()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        //    public IActionResult Gallery(int productCategoryId)
        //    {
        //        return View();
        //    }
        //    var products = _dbContext.Products.Where(
        //        p => p.ProductCategoryId == productCategoryId)
        //        .Include(p => p.Image);

        //        return View(products);
        //}
    }
}
