﻿using core_strength_yoga_products.Interfaces;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;

namespace core_strength_yoga_products.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSettings> _options;
        public ProductCategoryService(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _options = options;

            _httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductCategory>>(
                "/ProductCategories") ?? throw new Exception();
            
            return response;
        }
    }
}
