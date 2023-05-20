namespace core_strength_yoga_products.Models
{
    public class BasketItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

        public BasketItem() { }

        public static decimal CalculateTotalItemCost(decimal fullPrice, decimal priceAdjustment, int qty)
        {
            return qty * (fullPrice + priceAdjustment);
        }
    }
}
