namespace CarPlace.Models.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DealerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
    }
}
