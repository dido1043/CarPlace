using System.ComponentModel.DataAnnotations;

namespace CarPlace.Models.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        
        public int DealerId { get; set; }
        public Dealer MyProperty { get; set; }
        public int CarId { get; set; }
        
        public int Quantity { get; set; }
    }
}
