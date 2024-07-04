//using CarPlace.Data;
//using CarPlace.Data.Models;
//using CarPlace.Data.Models.IdentityModels;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace CarPlace.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly AppDbContext _context;

//        public AccountController(UserManager<User> userManager, AppDbContext context)
//        {
//            this._userManager = userManager;
//            this._context = context;
//        }
//        [HttpPost]
//        [Route("register")]
//        public async Task<IActionResult> Register(RegisterModel request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await _userManager.CreateAsync(
//                new User 
//                { 
//                    FirstName = request.FirstName,
//                    LastName = request.LastName,
//                    Email = request.Email
//                },
//                request.Password);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result);
//            }
//            return CreatedAtAction(nameof(Register), request);
//        }
//    }
//}
