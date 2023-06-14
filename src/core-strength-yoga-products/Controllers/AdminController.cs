using System.ComponentModel.DataAnnotations;
using core_strength_yoga_products.Data;
using core_strength_yoga_products.Models;
using core_strength_yoga_products.Models.Enums;
using core_strength_yoga_products.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Versioning;
using ProductCategory = core_strength_yoga_products.Models.ProductCategory;
using ProductType = core_strength_yoga_products.Models.ProductType;

namespace core_strength_yoga_products.Controllers;

public class AdminController: Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly core_strength_yoga_productsContext _dbContext;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IProductCategoryService _productCategoryService;
    private readonly IProductTypeService _productTypeService;
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;
    
    public AdminController(ILogger<AdminController> logger, IProductCategoryService productCategoryService, 
        IProductTypeService productTypeService, IProductService productService)
    {
        _logger = logger;
        _productCategoryService = productCategoryService;
        _productTypeService = productTypeService;
        _productService = productService;
    }
    
    
    
    public async Task<IActionResult> Index()
    {
        var home = new Home();
        
        var products = _productService.GetProducts().Result;
       
        home.products = products;
        return View(home);
    }
    
    public async Task<IActionResult> AddProducts()
    {
        var newProduct = new NewProduct();
        var categories = new List<ProductCategory>();
        var types = new List<ProductType>() ;
            
        var categoryResult = _productCategoryService.GetCategories().Result;
        var typeResult = _productTypeService.GetTypes().Result;
        var products = _productService.GetProducts().Result;
        
        newProduct.productCategories = categoryResult;
        newProduct.productTypes = typeResult;
        newProduct.products = products;
        return View(newProduct);
    }
    
     public async Task<IActionResult> AddProduct([FromForm]NewProduct newProduct)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            var categoryResult = _productCategoryService.GetCategories().Result;
            var typeResult = _productTypeService.GetTypes().Result;


            var selectedDepermant = categoryResult.FirstOrDefault(c => c.Id == newProduct.SelectedDepartmentId);
            var selectedCategory = typeResult.FirstOrDefault(t => t.Id == newProduct.SelectedCategoryId);
            
            newProduct.Path = path;
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(newProduct.ImageFile.FileName);
            string fileName = newProduct.ImageName + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                newProduct.ImageFile.CopyTo(stream);
            }            
            //returnUrl ??= Url.Content("~/");
            //if (ModelState.IsValid)
            //{
                var product = new Product();
                var image = new Image();
                var productCategory = new ProductCategory();
                var productType = new ProductType();
                var productAttribute = new ProductAttributes();
                productAttribute.Colour = Colour.Black;
                productAttribute.Gender = Gender.Unisex;
                productAttribute.StockLevel = 5;



                var productAttributes = new List<ProductAttributes>();
                productAttributes.Add(productAttribute);

                product.Name = newProduct.Name;
                product.FullPrice = newProduct.FullPrice;
                product.Description = newProduct.Description;
                image.ImageName = newProduct.ImageName;
                image.Alt = newProduct.Alt;
                image.Path = "/images/" + fileName;
                product.Image = image;
                product.ProductType = selectedCategory;
                product.ProductCategory = selectedDepermant;
                product.ProductAttributes = productAttributes;
                

                var result = _productService.AddProduct(product).Result;
                //product.ProductCategory;

                // If we got this far, something failed, redisplay form
                return RedirectToAction("Index", "Admin");
                //}

            return null;

        }
     
     public async Task<IActionResult> RemoveProduct(Product product)
     {
         var result = _productService.RemoveProduct(product.Id).Result;
         return RedirectToAction("Index", "Admin");
                

        }
}