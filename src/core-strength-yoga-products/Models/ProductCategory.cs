using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string ProductCategoryName { get; set; }
        public string Description { get; set; }

    public ProductCategory(int id, string productCategoryName, string description)
        {
            Id = id;
            ProductCategoryName = productCategoryName;
            Description = description;
        }
    }
    
}
