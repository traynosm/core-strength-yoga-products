using core_strength_yoga_products.Data;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;

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
        private readonly ICustomerService _customerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, core_strength_yoga_productsContext dbContext, 
            IHttpClientFactory clientFactory, IProductCategoryService productCategoryService,
            IProductTypeService productTypeService, IProductService productService, IBasketService basketService,
            ICustomerService customerService, UserManager<IdentityUser> userManager, IOrderService orderService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _clientFactory = clientFactory;
            _productCategoryService = productCategoryService;
            _productTypeService = productTypeService;
            _productService = productService;
            _basketService = basketService;
            _customerService = customerService;
            _userManager = userManager;
            _orderService = orderService;
        }


        public async Task<ActionResult> Index()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            var user = HttpContext.User.Identity;
            if (user == null || string.IsNullOrEmpty(user.Name))
            {
                return Redirect("/Identity/Account/Login");
            }

            var order = await BuildOrderFromCart(cart!, user);

            return View(order);
        }

        public async Task<ActionResult> Payment()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            var user = HttpContext.User.Identity;
            if (user == null || string.IsNullOrEmpty(user.Name))
            {
                return Redirect("/Identity/Account/Login");
            }

            var order = await BuildOrderFromCart(cart, user);

            //post to api
            
            var savedOrder = await _orderService.AddOrder(order);

            return RedirectToAction("Index", "Payment", new { Order = savedOrder});
        }

        private async Task<Order> BuildOrderFromCart(IEnumerable<BasketItem> cart, IIdentity user)
        {
            var productsInBasket = new List<Product>();
            foreach (var basketItem in cart)
            {
                var product = await _productService.GetProduct(basketItem!.ProductId) ?? 
                    throw new NullReferenceException();
                var productAttribute = product.ProductAttributes.FirstOrDefault(p => p.Id == basketItem.ProductAttributeId) ?? 
                    throw new NullReferenceException();

                productsInBasket.Add(product);
                basketItem.Product = product;
                basketItem.Colour = productAttribute.Colour;
                basketItem.Size = productAttribute.Size;
            }

            var customer = await _customerService.GetCustomerByUsername(user.Name!);

            var orderTotal = await _basketService.CalculateTotalBasketCost(cart);
            var order = new Order()
            {
                Items = cart,
                DateOfSale = DateTime.Now,
                OrderTotal = orderTotal,
                Customer = customer,
                CustomerId = customer.Id,
            };

            return order;
        }

    }
}
