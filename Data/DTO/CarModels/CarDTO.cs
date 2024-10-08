﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarPlace.Data.DTO.CarModels
{
    public class CarDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("hp")]
        public int HP { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; } 
    }
}
