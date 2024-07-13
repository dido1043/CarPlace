using CarPlace.Data;
using CarPlace.Data.Models;
using CarPlace.Data.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager, AppDbContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new User
                {
                    Email = request.Email,
                },
                request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(Register), request);
        }
        private static void JSONDeserializer()
        {

        }
    }
}
