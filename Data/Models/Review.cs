using CarPlace.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Models.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        
        public string CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public User Customer { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
