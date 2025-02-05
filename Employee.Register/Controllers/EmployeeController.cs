using Employee.Register.Application.Commands;
using Employee.Register.Application.Commands.Handlers;
using Employee.Register.Application.DTO;
using Employee.Register.Application.Queries;
using Employee.Register.Application.Queries.Handlers;
using Employee.Register.Domain.Entities;
using Employee.Register.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Register.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly CreateEmployeeCommandHandler handler;
        private readonly GetEmployeeQueryHandler _getHandler;
        private readonly UpdateEmployeeCommandHandler _updateHandler;
        private readonly DeleteEmployeeCommandhandler _deleteHandler;

        public EmployeeController(CreateEmployeeCommandHandler handler, GetEmployeeQueryHandler getHandler,
            UpdateEmployeeCommandHandler updateHandler, DeleteEmployeeCommandhandler deleteHandler)
        {
            this.handler = handler;
            this._getHandler = getHandler;
            this._updateHandler = updateHandler;
            this._deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid || request.ChargeId <= 0)
            {
                return BadRequest(ModelState);
            }


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

            var employee = await handler.Handle(command, cancellationToken);
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery();
            var employees = await _getHandler.Handle(query, cancellationToken);
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            await _updateHandler.Handle(command, cancellationToken);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _deleteHandler.Handle(command, cancellationToken);
            return NoContent();
        }

    }
}
