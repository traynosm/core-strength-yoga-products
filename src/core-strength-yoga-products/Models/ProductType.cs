using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        public ProductType() { }    

        public ProductType(int id, string productTypeName, string description, int imageId)
        {
            Id = id;
            ProductTypeName = productTypeName;
            Description = description;
            ImageId = imageId;  
        }

    }
}
