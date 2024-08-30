using Newtonsoft.Json;

namespace CarPlace.Data.DTO.ResponseModels
{
    public class LoginResponseModel
    {
        [JsonProperty("tokenType")]
        public string TokenType { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
