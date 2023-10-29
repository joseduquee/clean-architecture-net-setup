using AutoMapper;
using MediatR;
using Serilog;
using TimyApp.Application.Contracts.Persistence;
using TimyApp.Application.Exceptions;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateEmployeeCommandHandler(IAsyncRepository<Employee> employeeRepository, IMapper mapper, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeRepository.GetByIdAsync(request.Id);
            if (employeeToUpdate == null)
            {
                _logger.Error("Employee was not found");
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

            await _employeeRepository.UpdateAsync(employeeToUpdate);

            _logger.Information("Employee was updated");
        }
    }
}
