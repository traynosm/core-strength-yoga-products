using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class ProductAttributes
    {
        [Key]
        public int Id { get; set; }
        public int StockLevel { get; set; }
        public decimal PriceAdjustment { get; set; }
        public Enums.Colour Colour { get; set; }
        public Enums.Size Size { get; set; }
        public Enums.Gender Gender { get; set; }

        public ProductAttributes(int stockLevel, decimal priceAdjustment) 
        {
            StockLevel = stockLevel;
            PriceAdjustment = priceAdjustment;
        }
    }
}
