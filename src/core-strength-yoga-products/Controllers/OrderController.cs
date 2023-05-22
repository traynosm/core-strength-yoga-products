using core_strength_yoga_products.Data;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace core_strength_yoga_products.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly core_strength_yoga_productsContext _dbContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public OrderController(ILogger<OrderController> logger, core_strength_yoga_productsContext dbContext, 
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
        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

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

            var orderTotal = await _basketService.CalculateTotalBasketCost(cart);
            var order = new Models.Order()
            {
                Items = cart,
                DateOfSale = DateTime.Now,
                OrderTotal = orderTotal,
            };

            return View(order);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
