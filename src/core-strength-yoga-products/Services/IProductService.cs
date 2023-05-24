using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Services;

public interface IProductService
{
    Task<IEnumerable<Product>?> GetProducts();
    Task<IEnumerable<Product>?> GetProductsByTypeId(int id);
    Task<Product>? GetProduct(int id);
    Task<IEnumerable<Product>?> GetProductByAttribute(int categoryId, int productTypeId, int colourId, int sizeId, int genderId);
}
