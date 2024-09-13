using CarPlace.Data.Models;
using CarPlace.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.InteropServices.JavaScript;

namespace CarPlace.Data.DTO.ReviewModels
{
    public class ReviewDTO
    {
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("property")]
        public int Rating { get; set; }
    }
}
