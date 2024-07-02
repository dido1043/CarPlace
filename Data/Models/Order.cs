using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPlace.Models.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer MyProperty { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
