using CarPlace.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

public class CustomSignInManager<TUser> : SignInManager<User>
{
    public CustomSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<User> claimsFactory, 
        IOptions<IdentityOptions> optionsAccessor, 
        ILogger<SignInManager<User>> logger, 
        IAuthenticationSchemeProvider schemes, 
        IUserConfirmation<User> confirmation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
    }

    public override async Task SignInAsync(User user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
    {
        // Custom sign-in logic if needed
        await base.SignInAsync(user, authenticationProperties, authenticationMethod);
    }
}