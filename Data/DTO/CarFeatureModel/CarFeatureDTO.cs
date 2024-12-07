using CarPlace.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarPlace.Data.DTO.CarFeatureModel
{
    public class CarFeatureDTO
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("feature")]
        public string Feature { get; set; }
    }
}
