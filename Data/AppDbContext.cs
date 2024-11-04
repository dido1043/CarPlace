
using CarPlace.Data.Models;
using CarPlace.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Emit;

namespace CarPlace.Data
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {}
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("AspNetUsers");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles");

            builder.Entity<User>(b => b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken());

            builder.Entity<IdentityRole>().Property(r => r.ConcurrencyStamp)
            .IsConcurrencyToken();
            base.OnModelCreating(builder);
            
        }
    }
}
