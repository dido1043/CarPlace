using CarPlace.Data;
using CarPlace.Data.DTO.RequestModels;
using CarPlace.Data.DTO.ResponseModels;
using CarPlace.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
using System.Runtime.CompilerServices;
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
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Invalid user!");
            }

            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid credentials");
            }

            var role = await GetUserRole(user);

            
            var tokenType = "Bearer";
            var accessToken = await _userManager.GenerateUserTokenAsync(user, "CarPlace", role);
            var expiresIn = 3600; 
            var refreshToken = await _userManager.GenerateUserTokenAsync(user, "CarPlace", role);

            var response = new LoginResponseModel
            {
                TokenType = tokenType,
                AccessToken = accessToken,
                ExpiresIn = expiresIn,
                RefreshToken = refreshToken,
                Role = role,
            };
            return response;
        }

        private async Task<string> GetUserRole(User user)
        {

            var rolename = await _userManager.GetRolesAsync(user);
            return rolename.FirstOrDefault();
        }

    }
}

