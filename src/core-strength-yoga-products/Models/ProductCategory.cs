using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string ProductCategoryName { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        public ProductCategory(int id, string productCategoryName, string description, int imageId)
        {
            Id = id;
            ProductCategoryName = productCategoryName;
            Description = description;
            ImageId = imageId;
        }
    }
    
}
