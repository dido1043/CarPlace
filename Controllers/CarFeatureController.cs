using CarPlace.Data;
using CarPlace.Data.DTO.CarFeatureModel;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPlace.Controllers
{
    public class CarFeatureController : Controller
    {
        private readonly AppDbContext _context;
        public CarFeatureController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/cars/features/all")]
        public async Task<IActionResult> All()
        {
            var carFeatures = await _context.CarFeatures.Select(cf => new CarFeatureDTO
            {
                Id = cf.Id,
                CarId = cf.CarId,
                Feature = cf.Feature,
            }).ToListAsync();
            return Ok(carFeatures);
        }
        [HttpPost]
        [Route("/cars/features/add")]
        public async Task<IActionResult> Add([FromBody] CarFeatureDTO carFeature)
        {
            var currentCar = await _context.Cars.FindAsync(carFeature.CarId);

            if (currentCar == null)
            {
                return NotFound("Car not found");
            }

            var entity = new CarFeature()
            {
                Id = carFeature.Id,
                CarId = currentCar.Id,
                Feature = carFeature.Feature,
            };

            _context.CarFeatures.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(carFeature);
        }
        [HttpPut]
        [Route("/cars/features/edit/{cfId}")]
        public async Task<IActionResult> Edit(int cfId, [FromBody] CarFeatureDTO carFeature)
        {

            var currentFeature = await _context.CarFeatures.FindAsync(cfId);
            ValidateCarFeature(currentFeature);

            currentFeature.Feature = carFeature.Feature;
            _context.CarFeatures.Update(currentFeature);
            await _context.SaveChangesAsync();
            return Ok(carFeature);
        }

        [HttpDelete]
        [Route("/cars/features/delete/{cfId}")]
        public async Task<IActionResult> Delete(int cfId)
        {
            var currentFeature = await _context.CarFeatures.FindAsync(cfId);
            ValidateCarFeature(currentFeature);
               
            _context.CarFeatures.Remove(currentFeature);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void ValidateCarFeature(CarFeature currentFeature)
        {
            if (currentFeature == null)
            {
                throw new ArgumentException("Invalid car!");
            }
        }
    }
}
