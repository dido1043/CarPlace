using CarPlace.Data;
using CarPlace.Data.DTO.ReviewModels;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

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
        [Route("/cars/reviews/all")]
        public async Task<IActionResult> All()
        {
            var reviews = await _context.Reviews.Select(c => new ReviewDTO
            {
                Id = c.Id,
                CarId = c.CarId,
                Customer = _context.Users.FirstOrDefault(u => u.Id == c.CustomerId).UserName,
                Content = c.Content,
                Rating = c.Rating,
            }).ToListAsync();
            return Ok(reviews);
        }
        [HttpPost]
        [Route("/cars/reviews/add")]
        public async Task<IActionResult> Add([FromBody] ReviewDTO review)
        {
            var currentCar = await _context.Cars.FindAsync(review.CarId);

            if (currentCar == null)
            {
                return NotFound("Car not found");
            }

            var reviewEntity = new Review()
            {
                Id = review.Id,
                CarId = currentCar.Id,
                CustomerId = review.Customer,
                Content = review.Content,
                Rating = review.Rating,
            };

            _context.Reviews.Add(reviewEntity);
            await _context.SaveChangesAsync();
            return Ok(reviewEntity);
        }
        [HttpPut]
        [Route("/cars/reviews/edit/{reviewId}")]
        public async Task<IActionResult> Edit(int reviewId, [FromBody]ReviewDTO reviewDto)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                throw new Exception("Invalid review.");
            }

            review.Content = reviewDto.Content;
            review.Rating = reviewDto.Rating;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("/cars/reviews/delete/{reviewId}")]
        public async Task<IActionResult> Delete(int reviewId)
        {

            var review = await _context.Reviews.FindAsync(reviewId);

            if (review == null)
            {
                throw new Exception("Invalid review!");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
