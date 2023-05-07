using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_strength_yoga_products.Models
{
    public class ProductAttributes
    {
        [Key]
        public int Id { get; set; }
        public int StockLevel { get; set; }
        public decimal PriceAdjustment { get; set; }
        public int ColourId { get; set; }
        public virtual Colour? Colour { get; set; }
        public int SizeId { get; set; }
        public virtual Size? Size { get; set; }
        public int GenderId { get; set; }
        public virtual Gender? Gender { get; set; } 

        public ProductAttributes(int stockLevel, decimal priceAdjustment) 
        {
            StockLevel = stockLevel;
            PriceAdjustment = priceAdjustment;
        }
    }
}
