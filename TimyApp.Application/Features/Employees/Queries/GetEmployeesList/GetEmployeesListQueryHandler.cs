using AutoMapper;
using MediatR;
using TimyApp.Application.Contracts.Persistence;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, List<EmployeesListVm>>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IAsyncRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeesListVm>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = (await _employeeRepository.GetAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<EmployeesListVm>>(allEmployees);
        }
    }
}
