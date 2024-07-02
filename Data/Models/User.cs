using Microsoft.AspNetCore.Identity;

namespace CarPlace.Data.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Password { get; set; }

    }
}
