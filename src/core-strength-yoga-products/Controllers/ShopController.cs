using core_strength_yoga_products.Data;
using Microsoft.AspNetCore.Mvc;
using core_strength_yoga_products.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using core_strength_yoga_products.Models;
using Newtonsoft.Json;
using core_strength_yoga_products.Models.Enums;

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
            if (categories == null || !categories.Any())
            {
                return RedirectToAction("/Home/Index");
            }
            return View(categories);
        }
        public async Task<IActionResult> ProductTypes(int productCategoryId)
        {
            var types = await _productTypeService.GetTypesByCategoryId(productCategoryId);
            if (types == null || !types.Any())
            {
                return RedirectToAction("Index");
            }
            return View(types);
        }
        public async Task<IActionResult> Gallery(int productTypeId)
        {
            var products = await _productService.GetProductsByTypeId(productTypeId);
            if (products == null || !products.Any())
            {
                return RedirectToAction("Index");
            }
            ViewData["productCategoryId"] = products.Select(p => p.ProductCategory).First().Id;
            ViewData["ProductTypeId"] = productTypeId;
            return View(products);
        }
        public async Task<IActionResult> Product(int productId)
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            var product = await _productService.GetProduct(productId)!;
            ViewData["productTypeId"] = product.ProductType.Id;
            return View(product);
        }

        public async Task<IActionResult> Description()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> FilterProducts(int categoryId=0, int productTypeId = 0, int colourId=0, int sizeId=0, int genderId=0)
        {
            var products = await _productService.GetProductByAttribute(categoryId, productTypeId, colourId, sizeId, genderId);

            ViewData["productCategoryId"] = categoryId;
            ViewData["ProductTypeId"] = productTypeId;
            ViewData["genderId"] = genderId;
            ViewData["sizeId"] = sizeId;
            ViewData["colourId"] = colourId;

            return View("Gallery", products);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProductsFromPost(IFormCollection form)
        {
            var categoryId = int.Parse(form["ProductCategory"].ToString());
            var productTypeId = int.Parse(form["ProductType"].ToString());
            var colourId = int.Parse(form["Colour"].ToString());
            var sizeId = int.Parse(form["Size"].ToString());
            var genderId = int.Parse(form["Gender"].ToString());

            var products = await _productService.GetProductByAttribute(categoryId, productTypeId, colourId, sizeId, genderId);

            ViewData["productCategoryId"] = categoryId;
            ViewData["ProductTypeId"] = productTypeId;
            ViewData["genderId"] = genderId;
            ViewData["sizeId"] = sizeId;
            ViewData["colourId"] = colourId;

            return View("Gallery", products);
        }

        public async Task<IActionResult> Search(string query)
        {
            var products = await _productService.Search(query);

            ViewData["showFilter"] = false;

            return View("Gallery", products);
        }
    }
}
