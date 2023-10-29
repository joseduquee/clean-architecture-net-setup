using Microsoft.Extensions.Logging;
using TimyApp.Domain.Entities;

namespace TimyApp.Persistence
{
    public class TimyAppDbContextSeed
    {
        public static async Task SeedAsync(TimyAppDbContext context, ILogger<TimyAppDbContextSeed> logger)
        {
            if (!context.Employees!.Any())
            {
                context.Employees!.AddRange(GetPreconfigureEmployee());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed Data succesfull inserted in DB", typeof(TimyAppDbContextSeed).Name);
            }
        }

        private static IEnumerable<Employee> GetPreconfigureEmployee()
        {
            return new List<Employee>
            {
                new Employee
                {
                    CreatedBy = "Alexander Duque",
                    Name = "Alexander Duque",
                    Email = "alexander@gmail.com",
                    Location = "Valencia"
                },
                new Employee
                {
                    CreatedBy = "Antonio Duque",
                    Name = "Antonio Duque",
                    Email = "antonio@gmail.com",
                    Location = "Madrid"
                },

            };
        }
    }
}
