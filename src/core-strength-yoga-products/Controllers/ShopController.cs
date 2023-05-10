using core_strength_yoga_products.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace core_strength_yoga_products.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly core_strength_yoga_productsContext  _dbContext;

        public ShopController(ILogger<ShopController> logger, core_strength_yoga_productsContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var productCategories = _dbContext.Products.Select(
                p => p.ProductCategory).ToList();

            return View(productCategories);
        }

        public IActionResult Gallery(int productCategoryId) 
        {
            var products = _dbContext.Products.Where(
                p => p.ProductCategoryId == productCategoryId)
                .Include(p => p.Images);

            return View(products);
        }
    }
}
