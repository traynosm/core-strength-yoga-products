using static core_strength_yoga_products.Models.Global;


using core_strength_yoga_products.Models;
using core_strength_yoga_products.Models.Dtos;

namespace core_strength_yoga_products.Services;

public class ProductTypeService : IProductTypeService
{
    
    private readonly HttpClient _httpClient;
    

    public ProductTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseURI);
            
    }

    public async Task<IEnumerable<ProductTypeDto>> GetTypes()
    {

        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductTypeDto>>("/ProductTypes");
    }

}