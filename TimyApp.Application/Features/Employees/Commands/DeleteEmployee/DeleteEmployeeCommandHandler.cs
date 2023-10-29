using AutoMapper;
using MediatR;
using Serilog;
using TimyApp.Application.Contracts.Persistence;
using TimyApp.Application.Exceptions;
using TimyApp.Domain.Entities;

namespace TimyApp.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteEmployeeCommandHandler(IAsyncRepository<Employee> employeeRepository, IMapper mapper, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id);

            if(employeeToDelete == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            await _employeeRepository.DeleteAsync(employeeToDelete);
        }
    }
}
