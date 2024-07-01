namespace CarPlace.Models.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
