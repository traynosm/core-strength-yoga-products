using core_strength_yoga_products.Models.Dtos;

namespace core_strength_yoga_products.Services;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategoryDto>?> GetCategories();
}