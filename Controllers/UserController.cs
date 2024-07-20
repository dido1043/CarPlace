using CarPlace.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarPlace.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("/user/fav/{carId}")]
        public async Task<IActionResult> AddFavCar(int carId)
        {

            return View();
        }

    }
}
