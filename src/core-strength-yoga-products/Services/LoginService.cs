using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using core_strength_yoga_products.Interfaces;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Settings;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Newtonsoft.Json.Linq;

namespace core_strength_yoga_products.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContext _httpContext;
        private readonly IOptions<ApiSettings> _options;
        public LoginService(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _options = options;
            _httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);
        }

        public async Task<String> Login(UserModel userModel )
        {

            
            var content = new StringContent(JsonSerializer.Serialize<UserModel>(userModel).ToString(), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));  
            var result = await _httpClient.PostAsync("/auth/login", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            
            var jsonObject = JObject.Parse(resultContent);
            var tokenValue = jsonObject.GetValue("token").ToString();
            var tokenHandler = new JwtSecurityTokenHandler();

            // Read the JWT token
            var jwtToken = tokenHandler.ReadJwtToken(tokenValue);

            // Create a new ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(jwtToken.Claims);
            if (claimsIdentity.Name != null)
            {
                GlobalData.isSignedIn = true;
                GlobalData.Username = claimsIdentity.Name;
            }
            
            // Create a new ClaimsPrincipal and assign the ClaimsIdentity
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            
            // _signInManager.UserManager.FindByIdAsync(userModel.Username);
            //User.Claims = claimsPrincipal;
            
            return resultContent;
        }
        
        public async Task<String> Register(Customer customer )
        {

            
            var content = new StringContent(JsonSerializer.Serialize<Customer>(customer).ToString(), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));  
            var result = await _httpClient.PostAsync("/auth/register", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            
            var jsonObject = JObject.Parse(resultContent);
            var tokenValue = jsonObject.GetValue("token").ToString();
            var tokenHandler = new JwtSecurityTokenHandler();

            // Read the JWT token
            var jwtToken = tokenHandler.ReadJwtToken(tokenValue);

            // Create a new ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(jwtToken.Claims);
            if (claimsIdentity.Name != null)
            {
                GlobalData.isSignedIn = true;
                GlobalData.Username = claimsIdentity.Name;
            }
            
            // Create a new ClaimsPrincipal and assign the ClaimsIdentity
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            
            // _signInManager.UserManager.FindByIdAsync(userModel.Username);
            //User.Claims = claimsPrincipal;
            
            return resultContent;
        }
        
    }
}