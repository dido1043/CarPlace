using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CarPlace.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {

    }
}
