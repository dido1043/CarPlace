using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Models.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public int DealerId { get; set; }
        [ForeignKey(nameof(DealerId))]
        public Dealer Dealer { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
    }
}
