using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;

namespace core_strength_yoga_products.Services;

public class ProductTypeService : IProductTypeService
{
    private readonly IOptions<ApiSettings> _settings;
    private readonly HttpClient _httpClient;
    
    public ProductTypeService(HttpClient httpClient, IOptions<ApiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _httpClient.BaseAddress = new Uri(_settings.Value.BaseUrl);    
    }

    public async Task<IEnumerable<ProductType>> GetTypes()
    {
        var response =  await _httpClient.GetFromJsonAsync<IEnumerable<ProductType>>(
            "/api/v1/ProductTypes") ?? throw new Exception();

        return response;
    }
    public async Task<IEnumerable<ProductType>> GetTypesByCategoryId(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductType>>(
            $"/api/v1/ProductTypes/ByCategoryId/{id}") ?? throw new Exception();

        return response;
    }


}