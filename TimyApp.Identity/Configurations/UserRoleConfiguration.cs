using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimyApp.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3047d39d-0b73-440d-972e-6b6f348694f8",
                    UserId = "8cbb20c3-e7cc-441a-ae76-0a6cb2c2d4a3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "22ca0d20-7af2-484b-9522-adb20e98c0cf",
                    UserId = "890d9fea-70a9-48a2-a00c-2a26caba2a04"
                }
            );
        }
    }
}
