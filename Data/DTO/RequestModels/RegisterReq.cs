﻿using Newtonsoft.Json;

namespace CarPlace.Data.DTO.RequestModels
{
    public class RegisterReq
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
