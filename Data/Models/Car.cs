﻿using System.ComponentModel.DataAnnotations;

namespace CarPlace.Models.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int HP { get; set; }
        public string Description { get; set; }
    }
}
