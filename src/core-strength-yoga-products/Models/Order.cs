namespace core_strength_yoga_products.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual IEnumerable<BasketItem> Items { get; set; }
        public int CustomerId { get; set; }
        public DateTime? DateOfSale { get; set; }
        public decimal OrderTotal { get; set; }
        public bool IsPaid { get; set; }
        public int CustomerDetailId { get; set; }

        public Order() { }

        public Order(int id, DateTime? dateOfSale, decimal orderTotal, int customerId, bool isPaid)
        {
            Id = id;
            DateOfSale = dateOfSale;
            OrderTotal = orderTotal;
            CustomerId = customerId;
            IsPaid = isPaid;
        }
    }
}
