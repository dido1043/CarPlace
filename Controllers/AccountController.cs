using CarPlace.Data;
using CarPlace.Data.DTO.RequestModels;
using CarPlace.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CarPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;    
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            AppDbContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Invalid user!");
            }
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password,false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid result");
            }
            return Ok();
        }
    }
}
