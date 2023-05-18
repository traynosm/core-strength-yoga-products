using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }

        public ProductType() { }    

        public ProductType(int id, string productTypeName, string description, Image image)
        {
            Id = id;
            ProductTypeName = productTypeName;
            Description = description;
            Image = image;  
        }
    }
}
