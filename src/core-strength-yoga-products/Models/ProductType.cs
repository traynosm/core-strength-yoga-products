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

        public ProductType(int id, string productTypeName, string description)
        {
            Id = id;
            ProductTypeName = productTypeName;
            Description = description;
        }

    }
}
