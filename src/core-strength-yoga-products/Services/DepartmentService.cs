using static core_strength_yoga_products.Models.Global;


using core_strength_yoga_products.Models;
using core_strength_yoga_products.Models.Dtos;

namespace core_strength_yoga_products.Services;

public class DepartmentService : IDepartmentService
{
    
    private readonly HttpClient _httpClient;
    

    public DepartmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseURI);
            
    }

    public async Task<IEnumerable<ProductCategoryDto>> GetDepartments()
    {

        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductCategoryDto>>("/Products/ByType");
    }

}