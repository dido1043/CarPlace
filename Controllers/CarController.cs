using CarPlace.Data;
using CarPlace.Data.DTO.CarModels;
using CarPlace.Models.Models;
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
                    ImageUrl = c.ImageUrl,
                }).ToListAsync();

            return CreatedAtAction(nameof(All), cars);
        }
        [HttpPost]
        [Route("/cars/add")]
        public async Task<IActionResult> Add(CarDTO car)
        {

            var entity = new Car()
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                ImageUrl = car.ImageUrl,
                

            };
            if (!ModelState.IsValid)
            {
                throw new Exception("Invaid car data!");
            }
            _context.Cars.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Add), entity);
        }
    }
}
