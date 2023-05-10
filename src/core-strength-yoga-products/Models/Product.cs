using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal FullPrice { get; set; }
        public virtual ICollection<Image>? Images { get; set; }
        public virtual ICollection<ProductAttributes>? ProductAttributes { get; set; }

        public Product(int id, string name, string description, decimal fullPrice) 
        {
            Id = id;
            Name = name;
            Description = description;
            FullPrice = fullPrice;
        }
    }
}
