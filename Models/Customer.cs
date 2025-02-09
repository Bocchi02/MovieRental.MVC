namespace MovieRental.MVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public ICollection<RentalHeader> RentalHeaders { get; set; }
    }
}
