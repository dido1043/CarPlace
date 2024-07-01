namespace CarPlace.Models.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceDetails { get; set; }
    }
}
