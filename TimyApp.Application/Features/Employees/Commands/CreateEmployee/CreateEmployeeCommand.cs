using MediatR;
using TimyApp.Application.Mappings;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IMapFrom<Employee>, IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

    }
}
