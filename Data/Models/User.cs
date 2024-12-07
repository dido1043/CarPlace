using CarPlace.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace CarPlace.Data.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }

    }
}
