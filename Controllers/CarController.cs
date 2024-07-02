using Microsoft.AspNetCore.Mvc;

namespace CarPlace.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
