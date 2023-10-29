using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimyApp.Identity.Models;

namespace TimyApp.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "8cbb20c3-e7cc-441a-ae76-0a6cb2c2d4a3",
                    Email = "alexander@gmail.com",
                    NormalizedEmail = "ALEXANDER@GMAIL.COM",
                    FirstName = "Alexander",
                    LastName = "Duque",
                    UserName = "alexanderduque",
                    NormalizedUserName = "ALEXANDERDUQUE",
                    PasswordHash = hasher.HashPassword(null, "TimyApp2023"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "890d9fea-70a9-48a2-a00c-2a26caba2a04",
                    Email = "antonio@gmail.com",
                    NormalizedEmail = "ANTONIO@GMAIL.COM",
                    FirstName = "Antonio",
                    LastName = "Duque",
                    UserName = "antonioduque",
                    NormalizedUserName = "ANTONIODUQUE",
                    PasswordHash = hasher.HashPassword(null, "TimyApp2023"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
