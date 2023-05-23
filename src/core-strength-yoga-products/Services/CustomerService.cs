using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace core_strength_yoga_products.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<ApiSettings> _options;

    public CustomerService(HttpClient httpClient, IOptions<ApiSettings> options)
    {
        _httpClient = httpClient;
        _options = options;
        _httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);
    }

    public async Task<Customer> GetCustomerByUsername(string username)
    {
        var response = await _httpClient.GetFromJsonAsync<Customer>(
            $"/Customer/GetByUserName/{username}") ?? throw new Exception();

        return response;
    }
}


