using Newtonsoft.Json;

namespace core_strength_yoga_products.Models
{
    public class BasketItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product{ get; set; }
        public int ProductAttributeId { get; set; }
        [JsonIgnore]
        public Enums.Colour? Colour { get; set; }
        [JsonIgnore]
        public Enums.Size? Size { get; set; }
        [JsonIgnore]
        public Enums.Gender? Gender { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

        public BasketItem() { }

        public static decimal CalculateTotalItemCost(decimal fullPrice, decimal priceAdjustment, int qty)
        {
            return qty * (fullPrice + priceAdjustment);
        }
    }
}
