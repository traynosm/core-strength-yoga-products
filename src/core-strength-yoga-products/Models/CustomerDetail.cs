namespace core_strength_yoga_products.Models
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<AddressDetail> Addresses { get; set; }

        public CustomerDetail() { }

        public CustomerDetail(int id, int customerId, string firstName, string surname,
            string phoneNo, string email)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            PhoneNo = phoneNo;
            Email = email;
        }
    }
}
