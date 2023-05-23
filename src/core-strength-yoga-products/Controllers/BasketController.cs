using core_strength_yoga_products.Data;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;

namespace core_strength_yoga_products.Controllers
{
    public class BasketController : Controller
    {
        private readonly ILogger<BasketController> _logger;
        private readonly core_strength_yoga_productsContext _dbContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;


        public BasketController(ILogger<BasketController> logger, core_strength_yoga_productsContext dbContext,
            IHttpClientFactory clientFactory, IProductCategoryService productCategoryService,
            IProductTypeService productTypeService, IProductService productService, IBasketService basketService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _clientFactory = clientFactory;
            _productCategoryService = productCategoryService;
            _productTypeService = productTypeService;
            _productService = productService;
            _basketService = basketService;
        }
        // GET: BasketController
        public async Task<ActionResult> Index()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<IEnumerable<BasketItem>>(sessionCart!);

            var productsInBasket = new List<Product>();
            foreach (var basketItem in cart)
            {
                var product = await _productService.GetProduct(basketItem.ProductId);
                var productAttribute = product.ProductAttributes.FirstOrDefault(p => p.Id == basketItem.ProductAttributeId);
                productsInBasket.Add(product);
                basketItem.Product = product;
                basketItem.Colour = productAttribute.Colour;
                basketItem.Size = productAttribute.Size;
            }

            decimal totalBasketCost = await _basketService.CalculateTotalBasketCost(cart);

            return View((cart, totalBasketCost));
        }

        // POST: BasketController/AddOrRemove/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrRemove(int id, IFormCollection collection)
        {
            try
            {
                var productId = int.Parse(collection["ProductId"].ToString());
                var productAttributeId = int.Parse(collection["ProductAttributeId"].ToString());
                var quantity = int.Parse(collection["Quantity"].ToString());

                var sessionCart = HttpContext.Session.GetString("cart");
                var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

                var existingBasketItem = cart!
                    .Where(c => c.ProductId == productId && c.ProductAttributeId == productAttributeId)
                    .FirstOrDefault();

                var costedItem = await GetCostedItem(existingBasketItem, productId, productAttributeId, quantity);

                if (existingBasketItem == null)
                {
                    cart!.Add(costedItem!);
                }
                else
                {
                    cart!
                        .Where(c => c.ProductId == productId && c.ProductAttributeId == productAttributeId)
                        .FirstOrDefault().TotalCost = costedItem.TotalCost;
                }

                decimal totalBasketCost = await _basketService.CalculateTotalBasketCost(cart);

                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

                return RedirectToAction("Product", "Shop", new { ProductId = productId });
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteFromBasket(int productId, int productAttributeId)
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            var existingBasketItem = cart!
                .Where(c => c.ProductId == productId && c.ProductAttributeId == productAttributeId)
                .FirstOrDefault();

            cart = cart!.Where(c => c.ProductId != productId && c.ProductAttributeId != productAttributeId).ToList();         

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Index");
        }
    

        private async Task<BasketItem> GetCostedItem(BasketItem? existingBasketItem, int productId, int productAttributeId, int quantity = 0)
        {
            BasketItem basketItem = new BasketItem();

            if (existingBasketItem == null)
            {
                basketItem.ProductId = productId;
                basketItem.ProductAttributeId = productAttributeId;
                basketItem.Quantity = quantity;          
            }
            else
            {
                basketItem = existingBasketItem;
                basketItem.Quantity = quantity;
            }

            return await _basketService.CalculateItemTotal(basketItem);
        }
    }
}
