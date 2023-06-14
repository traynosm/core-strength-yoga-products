using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;

namespace core_strength_yoga_products.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IOptions<ApiSettings> _settings;
    private readonly HttpClient _httpClient;
    
    public DepartmentService(HttpClient httpClient, IOptions<ApiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _httpClient.BaseAddress = new Uri(_settings.Value.BaseUrl);         
    }

    public async Task<IEnumerable<ProductCategory>> GetDepartments()
    {
        var response =  await _httpClient.GetFromJsonAsync<IEnumerable<ProductCategory>>(
            "/api/v1/Products/ByType") ?? throw new Exception();

        return response;
    }

}