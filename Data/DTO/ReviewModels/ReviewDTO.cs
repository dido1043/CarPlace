using Newtonsoft.Json;

namespace CarPlace.Data.DTO.ReviewModels
{
    public class ReviewDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
