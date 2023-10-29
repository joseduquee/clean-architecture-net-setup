using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimyApp.Application.Features.Employees.Commands.CreateEmployee;
using TimyApp.Application.Features.Employees.Commands.DeleteEmployee;
using TimyApp.Application.Features.Employees.Commands.UpdateEmployee;
using TimyApp.Application.Features.Employees.Queries.GetEmployeesList;

namespace TimyApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEmployees")]
        [Authorize(Roles = "Employee")]

        //[ProducesDefaultResponseType] averiguar
        [ProducesResponseType(typeof(List<EmployeesListVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeesListVm>>> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesListQuery());
            return Ok(employees);
        }

        [HttpPost(Name = "AddEmployee")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var response = await _mediator.Send(createEmployeeCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(deleteEmployeeCommand);
            return NoContent();
        }
    }
}
