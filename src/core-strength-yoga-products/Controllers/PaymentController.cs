using core_strength_yoga_products.Data;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace core_strength_yoga_products.Controllers
{
    public class PaymentController : Controller
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

        public PaymentController(ILogger<OrderController> logger, core_strength_yoga_productsContext dbContext,
            IHttpClientFactory clientFactory, IProductCategoryService productCategoryService,
            IProductTypeService productTypeService, IProductService productService, IBasketService basketService,
            ICustomerService customerService, UserManager<IdentityUser> userManager)
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
        }

        public IActionResult Index(Order order)
        {
            return View(order);
        }
    }
}
