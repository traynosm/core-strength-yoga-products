namespace core_strength_yoga_products.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsGdpr { get; set; }
        public int CustomerDetailId { get; set; }
        public CustomerDetail CustomerDetail { get; set; }

        public Customer() { }

        public Customer(int id, string identityUserName, DateTime createdAt, bool isActive, bool isGdpr)
        {
            Id = id;
            IdentityUserName = identityUserName;
            CreatedAt = createdAt;
            IsActive = isActive;
            IsGdpr = isGdpr;
        }
    }
}
