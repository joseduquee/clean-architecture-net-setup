using Microsoft.EntityFrameworkCore;
using TimyApp.Application.Contracts.Persistence;
using TimyApp.Domain.Entities;

namespace TimyApp.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TimyAppDbContext context) : base(context)
        {
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            return await _context.Employees.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
