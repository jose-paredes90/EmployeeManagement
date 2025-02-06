using Employee.Register.Application.Commands;
using Employee.Register.Application.DTO;
using Employee.Register.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Register.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var command = new CreateEmployeeCommand()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                ChargeId = request.ChargeId,
                AFP = request.AFP,
                Birthdate = request.Birthdate,
                Hiredate = request.Hiredate,
                Salary = request.Salary,
            };

            var employee = await mediator.Send(command, cancellationToken);
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery();
            var employees = await mediator.Send(query, cancellationToken);
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var command = new UpdateEmployeeCommand
            {
                Id = id,
                Name = request.Name,
                Lastname = request.Lastname,
                Birthdate = request.Birthdate,
                Hiredate = request.Hiredate,
                AFP = request.AFP,
                ChargeId = request.ChargeId,
                Salary = request.Salary
            };

            await mediator.Send(command, cancellationToken);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}