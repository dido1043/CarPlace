using CarPlace.Data;
using CarPlace.Data.DTO.CarModels;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        //TODO: Add get method
        [HttpPut]
        [Route("/cars/edit/{carId}")]
        public async Task<IActionResult> Edit(int carId, [FromBody]CarDTO carDto)
        {
            if (carId != carDto.Id)
            {
                return BadRequest();
            }
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                throw new Exception("Invalid car id.");
            }
            car.Make = carDto.Make;
            car.Model = carDto.Model;
            car.Year = carDto.Year;
            car.Price = carDto.Price;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //TODO: Http get method for id
        [HttpDelete]
        [Route("/cars/delete/{carId}")]
        public async Task<IActionResult> Delete(int carId, CarDTO carDTO)
        {
            if (carId != carDTO.Id)
            {
                return BadRequest();  
            }
            var car = await _context.Cars.FindAsync(carId);

            if (car == null)
            {
                throw new Exception("Invalid car!");
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private string GetUser()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
