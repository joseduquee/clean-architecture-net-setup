using TimyApp.Application.Mappings;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Queries.GetEmployeesList
{
    public class EmployeesListVm : IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        //public Guid ProjectId { get; set; }
        //public virtual Project? Project { get; set; }
        //public Guid? TeamId { get; set; }
        //public virtual Team? Team { get; set; }
    }
}
