using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Models.Models
{
    public class CarFeature
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public string Feature { get; set; }
    }
}
