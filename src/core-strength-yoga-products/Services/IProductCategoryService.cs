using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Services;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategory>?> GetCategories();
}