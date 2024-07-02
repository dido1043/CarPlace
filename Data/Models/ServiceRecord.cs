using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Models.Models
{
    public class ServiceRecord
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        [Required]
        public string ServiceDetails { get; set; }
    }
}
