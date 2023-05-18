using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetCategories();
    }
}
