using static core_strength_yoga_products.Models.Global;


using core_strength_yoga_products.Models;
using core_strength_yoga_products.Models.Dtos;

namespace core_strength_yoga_products.Services;

public class ProductCategoryService : IProductCategoryService
{
    
    private readonly HttpClient _httpClient;
    

    public ProductCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseURI);
            
    }

    public async Task<IEnumerable<ProductDto>> GetCategories()
    {

        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/Products/Categories");
    }

}