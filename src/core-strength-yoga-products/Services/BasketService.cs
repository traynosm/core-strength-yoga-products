using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using System.Net.Http;

namespace core_strength_yoga_products.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSettings> _settings;


        public BasketService(HttpClient httpClient, IOptions<ApiSettings> settings)
        {
            _settings = settings;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_settings.Value.BaseUrl);

        }
        public async Task<BasketItem?> CalculateItemTotal(BasketItem basketItem)
        {
            var response = await _httpClient.PostAsJsonAsync("/BasketItem/CalculateItemTotalCost", basketItem);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BasketItem>(content);

            return result;
        }
        public async Task<decimal> CalculateTotalBasketCost(IEnumerable<BasketItem> basketItems)
        {
            var response = await _httpClient.PostAsJsonAsync("/BasketItem/CalculateTotalBasketCost", basketItems);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<decimal>(content);

            return result;
        }
    }
}
