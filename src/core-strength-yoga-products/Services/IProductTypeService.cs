

using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Services;

public interface IProductTypeService
{
    Task<IEnumerable<ProductType>?> GetTypes();

    Task<IEnumerable<ProductType>> GetTypesByCategoryId(int id);


}