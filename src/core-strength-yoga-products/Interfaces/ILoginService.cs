using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Mvc;

namespace core_strength_yoga_products.Interfaces
{
    public interface ILoginService
    {
        Task<HttpResponseMessage> Login(UserModel userModel);
        Task<HttpResponseMessage> Register(Customer customer);

        Task<String> Dummy();
    }
}