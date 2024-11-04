using CarPlace.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Data.Models
{
    public class RentRequest
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}
