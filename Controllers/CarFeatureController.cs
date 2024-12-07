using CarPlace.Data.DTO.CarFeatureModel;
using Microsoft.AspNetCore.Mvc;

namespace CarPlace.Controllers
{
    public class CarFeatureController : Controller
    {
        [HttpGet]
        [Route("/cars/features/all")]
        public async Task<IActionResult> All()
        {
            return View();
        }
        [HttpPost]
        [Route("/cars/features/add")]
        public async Task<IActionResult> Add([FromBody] CarFeatureDTO carFeature)
        {
            return Ok(carFeature);
        }
        [HttpPut]
        [Route("/cars/features/edit/{cfId}")]
        public async Task<IActionResult> Edit(int cfId, [FromBody] CarFeatureDTO carFeature) 
        { 
            return Ok(carFeature);
        }
    }
}
