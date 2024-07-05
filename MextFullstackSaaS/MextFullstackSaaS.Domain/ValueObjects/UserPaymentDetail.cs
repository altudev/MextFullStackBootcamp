namespace MextFullstackSaaS.Domain.ValueObjects
{
    public class UserPaymentDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
        public string Address { get; set; }
        public string Ip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
