using CarPlace.Data;
using CarPlace.Data.DTO.CarModels;
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
            var favCar = await _context.Cars.FindAsync(carId);
            if (favCar == null)
            {
                throw new Exception("Invalid car");
            }
            //TODO
            //var favList = _context.Cars.Select(u => u.User.FavCars).ToList();
            //favList.Add();
            return View();
        }

    }
}
