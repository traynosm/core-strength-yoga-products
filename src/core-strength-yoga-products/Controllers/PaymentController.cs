using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace core_strength_yoga_products.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}