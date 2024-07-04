﻿using CarPlace.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace CarPlace.Data.Models
{
    public class User:IdentityUser
    {
        public ICollection<Car> FavCars { get; set; }

    }
}
