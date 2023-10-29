using MediatR;

namespace TimyApp.Application.Features.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest<List<EmployeesListVm>>
    {
    }
}
