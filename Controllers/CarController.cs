using CarPlace.Data;
using CarPlace.Data.DTO.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPlace.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        public CarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/cars")]
        public async Task<IActionResult> All()
        {
            var cars = await _context.Cars
                .Select(c => new CarDTO 
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                }).ToListAsync();

            return CreatedAtAction(nameof(All), cars);
        }
    }
}
