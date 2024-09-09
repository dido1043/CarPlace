using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CarPlace.Controllers
{
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        [HttpGet]
        [Route("cars/reviews/all")]
        public async Task<IActionResult> All()
        {
            return View();
        }
        [HttpPost]
        [Route("cars/reviews/add")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        
    }
}
