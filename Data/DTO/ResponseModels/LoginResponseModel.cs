using Newtonsoft.Json;

namespace CarPlace.Data.DTO.ResponseModels
{
    public class LoginResponseModel
    {

        public string TokenType { get; set; }
        public string Asd { get; set; }
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}
