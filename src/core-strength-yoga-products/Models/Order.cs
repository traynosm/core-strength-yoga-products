using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Customer? Customer { get; set; }
        public DateTime? DateOfSale { get; set; }
        public decimal OrderTotal { get; set; }

        public Order (int id, DateTime? dateOfSale, decimal orderTotal)
        {
            Id = id;
            DateOfSale = dateOfSale;
            OrderTotal = orderTotal;
        }
    }
}
