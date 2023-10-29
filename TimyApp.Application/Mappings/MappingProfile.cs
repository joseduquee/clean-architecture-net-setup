using AutoMapper;
using TimyApp.Application.Features.Employees.Commands.CreateEmployee;
using TimyApp.Application.Features.Employees.Commands.UpdateEmployee;
using TimyApp.Application.Features.Employees.Queries.GetEmployeesList;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeesListVm>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap();
        }
    }
}
