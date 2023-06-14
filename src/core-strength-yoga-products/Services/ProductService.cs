using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace core_strength_yoga_products.Services
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSettings> _settings;


        public ProductService(HttpClient httpClient, IOptions<ApiSettings> settings)
        {
            _settings = settings;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_settings.Value.BaseUrl);
        }

        public async Task<IEnumerable<Product>?> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/v1/Products");
        }
        public async Task<IEnumerable<Product>?> GetProductsByTypeId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"/api/v1/Products/ByType/{id}");
        }
        public async Task<Product?> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"/api/v1/Products/{id}");
        }
        public async Task<IEnumerable<Product>?> GetProductByAttribute(int categoryId, int productTypeId, int colourId, int sizeId, int genderId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>(
                $"/api/v1/Products/FilterOnAttribute/ProductCategory={categoryId}/ProductType={productTypeId}/Colour={colourId}/Size={sizeId}/Gender={genderId}");
        }
        [HttpPost]
        public async Task<IEnumerable<Product>?> Search([Bind]string query)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"/api/v1/Products/Search/{query}");
        }
    }
}
