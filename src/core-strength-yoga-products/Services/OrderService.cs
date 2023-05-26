using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace core_strength_yoga_products.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSettings> _settings;


        public OrderService(HttpClient httpClient, IOptions<ApiSettings> settings)
        {
            _settings = settings;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_settings.Value.BaseUrl);

        }

        public async Task<Order?> AddOrder(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/Order", order);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Order>(content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return result;
        }

    }
}
