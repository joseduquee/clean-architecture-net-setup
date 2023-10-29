using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimyApp.Identity.Configurations;
using TimyApp.Identity.Models;

namespace TimyApp.Identity
{
    public class TimyAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TimyAppIdentityDbContext(DbContextOptions<TimyAppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
