﻿using CarPlace.Data;
using CarPlace.Data.Models;
using CarPlace.Data.Models.IdentityModels;
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
            this._userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new User 
                { 
                    UserName =  $"{request.FirstName} {request.LastName}!",
                    Email = request.Email
                },
                request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(Register), request);
        }
    }
}