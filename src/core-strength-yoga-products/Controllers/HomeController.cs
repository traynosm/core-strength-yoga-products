﻿using core_strength_yoga_products.Interfaces;
using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using core_strength_yoga_products.Services;

namespace core_strength_yoga_products.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        private readonly DepartmentService _departmentService;

        public HomeController(ILogger<HomeController> logger, DepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = _departmentService.GetDepartments().Result;
            return View(departments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}