using Newtonsoft.Json;

namespace CarPlace.Data.DTO.RentRequestModel
{
    
    public class RentRequestModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("carId")]
        public int CarId { get; set; }
    }
}
