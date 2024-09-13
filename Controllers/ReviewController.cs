using CarPlace.Data;
using CarPlace.Data.DTO.ReviewModels;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Policy;

namespace CarPlace.Controllers
{
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("cars/reviews/all")]
        public async Task<IActionResult> All()
        {
            var currentUser = User.Identity?.Name;
            var reviews = await _context.Reviews.Select(c => new ReviewDTO
            {

                CarId = c.CarId,
                Customer = currentUser,
                Content = c.Content,
                Rating = c.Rating,

            }).ToListAsync();
            return Ok(reviews);
        }
        [HttpPost]
        [Route("cars/reviews/add")]
        public async Task<IActionResult> Add([FromBody] ReviewDTO review)
        {
            var currentCar = await _context.Cars.FindAsync(review.CarId);

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = User.Identity?.Name;
            if (currentCar == null)
            {
                return NotFound("Car not found");
            }

            var reviewEntity = new Review
            {
                CarId = currentCar.Id,
                CustomerId = currentUserId,
                Content = review.Content,
                Rating = review.Rating,
            };

            _context.Reviews.Add(reviewEntity);
            await _context.SaveChangesAsync();
            return Ok(reviewEntity);
        }

    }
}
