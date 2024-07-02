using System.ComponentModel.DataAnnotations;

namespace CarPlace.Models.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
