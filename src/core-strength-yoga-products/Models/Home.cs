namespace core_strength_yoga_products.Models;

public class Home
{
    public IEnumerable<ProductCategory> productCategories { get; set; }
    public IEnumerable<ProductType> productTypes { get; set; }

    public Home() { }
}