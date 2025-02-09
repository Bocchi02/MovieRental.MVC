using System.Text.Json.Serialization;

namespace MovieRental.MVC.Models
{
    public class RentalHeaderDetail
    {
        public int RentalHeaderDetailId { get; set; }
        public int RentalHeaderId { get; set; }
        public int MovieId { get; set; }
        public string Status { get; set; }
        public RentalHeader? RentalHeader { get; set; }
        public Movie? Movie { get; set; }
    }
}
