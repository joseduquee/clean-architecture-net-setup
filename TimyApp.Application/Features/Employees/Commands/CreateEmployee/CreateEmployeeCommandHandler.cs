using AutoMapper;
using MediatR;
using Serilog;
using TimyApp.Application.Contracts.Persistence;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateEmployeeCommandHandler(IAsyncRepository<Employee> employeeRepository, IMapper mapper, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Employee>(request);
            var employee = await _employeeRepository.AddAsync(employeeEntity);
            _logger.Information($"Employee {employee.Name} was succesfull created");
            return employee.Id;
        }
    }
}
