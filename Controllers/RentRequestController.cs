using CarPlace.Data;
using CarPlace.Data.DTO.RentRequestModel;
using CarPlace.Data.Models;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace CarPlace.Controllers
{
    public class RentRequestController : Controller
    {
        private readonly AppDbContext _context;
        public RentRequestController(AppDbContext context)
        {
            _context = context;
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("cars/requests/all")]
        public async Task<IActionResult> AllRequests()
        {
            var requests = await _context.RentRequests.Select(rr => new RentRequestModel()
            {
                Id = rr.Id,
                User = _context.Users.FirstOrDefault(u => u.Id == rr.UserId).UserName,
                CarId = rr.CarId,

            }).ToListAsync();
            return Ok(requests);
        }

        [HttpPost]
        [Route("cars/requests/add")]
        public async Task<IActionResult> AddRequest([FromBody] RentRequestModel model)
        {
            var currentCar = await _context.Cars.FindAsync(model.CarId);

            if (currentCar == null)
            {
                return NotFound();
            }

            var requestModel = new RentRequest()
            {
                Id = model.Id,
                UserId = model.User,
                CarId = model.CarId,
            };

            _context.RentRequests.AddAsync(requestModel);
            await _context.SaveChangesAsync();
            return Ok(requestModel);
        }
    }
}
