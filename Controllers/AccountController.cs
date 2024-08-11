using CarPlace.Data;
using CarPlace.Data.DTO.RequestModels;
using CarPlace.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
namespace CarPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appUser = new User
            {
                Email = request.Email,
            };
            
            var result = await _userManager.CreateAsync(appUser, request.Password);




            return CreatedAtAction(nameof(Register), request);
        }
        [HttpPost]
        public async Task<IActionResult> Login()
        {

            return Ok();
        }
    }
}
