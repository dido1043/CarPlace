using Newtonsoft.Json;

namespace CarPlace.Data.DTO.ServiceRecordsModel
{
    public class ServiceRecordDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("serviceDate")]
        public DateTime ServiceDate { get; set; }
        [JsonProperty("serviceDetails")]
        public string ServiceDetails { get; set; }
    }
}
