using System.Runtime.InteropServices;
using Microsoft.Build.Framework;

namespace core_strength_yoga_products.Models;

public class NewProduct
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImageName { get; set; }
    [Required]
    public string Alt { get; set; }
    [Required]
    public string Path { get; set; }
    [Required]
    public decimal FullPrice { get; set; }
    [Required]
    public int SelectedDepartmentId { get; set; }
    [Required]
    public int SelectedCategoryId { get; set; }
    [Required]
    public IFormFile ImageFile { get; set; }
    
    public IEnumerable<ProductCategory> productCategories { get; set; }
    public IEnumerable<ProductType> productTypes { get; set; }
    public IEnumerable<Product> products { get; set; }
}