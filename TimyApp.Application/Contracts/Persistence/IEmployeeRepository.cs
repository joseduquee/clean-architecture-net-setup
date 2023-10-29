using TimyApp.Domain.Entities;

namespace TimyApp.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<Employee> GetEmployeeByName(string name);
    }
}
