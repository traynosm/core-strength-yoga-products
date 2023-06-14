using core_strength_yoga_products.Models;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace core_strength_yoga_products.Controllers
{
    public class LogoutPController : Controller
    {

        [HttpGet]
        public IActionResult Logout()
            {
                GlobalData.EndSession();
                return View();
            }

            
        
    }



}