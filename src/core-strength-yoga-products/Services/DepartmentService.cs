using core_strength_yoga_products.Interfaces;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace core_strength_yoga_products.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSettings> _options;
        public DepartmentService(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _options = options;

            _httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);
        }

        public async Task<IEnumerable<ProductType>> GetDepartments()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductType>>(
                "/ProductTypes") ?? throw new Exception();

            return response;
        }
    }
}
