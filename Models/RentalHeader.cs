namespace MovieRental.MVC.Models
{
    public class RentalHeader
    {
        public int RentalHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<RentalHeaderDetail> RentalHeaderDetails { get; set; } = new List<RentalHeaderDetail>();
    }
}
