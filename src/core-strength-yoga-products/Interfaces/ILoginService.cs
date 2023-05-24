using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Mvc;

namespace core_strength_yoga_products.Interfaces
{
    public interface ILoginService
    {
        Task<String> Login(UserModel userModel);
        Task<String> Register(Customer customer);
    }
}