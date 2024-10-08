using CarPlace.Data;
using CarPlace.Data.DTO.CarModels;
using CarPlace.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPlace.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public UserController(AppDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        [Route("/me")]
        public async Task<ActionResult<string>> Me(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            return roles.FirstOrDefault();
        }

        [HttpGet]
        [Route("/id")]
        public async Task<ActionResult<string>> Id(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user.Id;
        }

    }
}
