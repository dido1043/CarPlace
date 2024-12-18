using CarPlace.Data;
using CarPlace.Data.DTO.RequestModels;
using CarPlace.Data.DTO.ResponseModels;
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
        public async Task<IActionResult> Register([FromBody] RegisterReq request)
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

        //[HttpPost]
        //[Route("/originalLogin")]
        public async Task<IActionResult> Login([FromBody] LoginReq request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                var role = await GetUserRole(user);
               

                Console.WriteLine(role);
                if (string.IsNullOrEmpty(role))
                {
                    throw new Exception("Error!");
                }

                var tokenType = "Bearer";
                var accessToken = await _userManager.GenerateUserTokenAsync(user, "CarPlace", role);
                var expiresIn = 3600;
                var refreshToken = await _userManager.GenerateUserTokenAsync(user, "CarPlace", role);

                var response = new LoginResponseModel
                {
                    TokenType = tokenType,
                    Asd = "asd",
                    AccessToken = accessToken,
                    ExpiresIn = expiresIn,
                    RefreshToken = refreshToken,
                    Role = role,
                };
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError); ;
            }

        }

        private async Task<string> GetUserRole(User user)
        {

            var rolename = await _userManager.GetRolesAsync(user);
            return rolename.FirstOrDefault();
        }

    }
}

