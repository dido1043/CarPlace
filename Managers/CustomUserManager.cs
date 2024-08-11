﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace CarPlace.Managers
{
    public class CustomUserManager<TUser> : UserManager<TUser> where TUser : class
    {
        public CustomUserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher,
            IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override async Task<IdentityResult> CreateAsync(TUser user, string password)
        {
            var result = await base.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var defaultRole = "Client"; // Change to your default role name
                await AddToRoleAsync(user, defaultRole);
            }

            return result;
        }
    }
}
