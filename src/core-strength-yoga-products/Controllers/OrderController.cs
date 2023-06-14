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
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IProductService productService, IBasketService basketService,
            ICustomerService customerService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _basketService = basketService;
            _customerService = customerService;
            _orderService = orderService;
        }


        public async Task<ActionResult> Index()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            //var user = HttpContext.User.Identity;
            if (!GlobalData.isSignedIn)
            {
                return Redirect("/Identity/Account/Login");
            }

            var order = await BuildOrderFromCart(cart!);

            return View(order);
        }

        public async Task<ActionResult> Payment()
        {
            var sessionCart = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<List<BasketItem>>(sessionCart!);

            if (!GlobalData.isSignedIn)
            {
                return Redirect("/Identity/Account/Login");
            }

            var order = await BuildOrderFromCart(cart);

            //post to api
            
            var savedOrder = await _orderService.AddOrder(order);

            return RedirectToAction("Index", "Payment", new { Order = savedOrder});
        }

        private async Task<Order> BuildOrderFromCart(IEnumerable<BasketItem> cart)
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

            var customer = await _customerService.GetCustomerByUsername(GlobalData.Username);

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
