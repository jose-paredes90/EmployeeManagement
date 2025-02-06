using Employee.Register.Domain.Interfaces;
using MediatR;
using System.Security;
using static Employee.Register.Middleware.Exceptions.BasicExceptions;

namespace Employee.Register.Application.Commands.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _empleadoRepository.GetById(request.Id);
            if (employee == null) throw new NotFoundException("Empleado no encontrado");

            employee.Hiredate = request.Hiredate;
            employee.Name = request.Name;
            employee.Lastname = request.Lastname;
            employee.AFP = request.AFP;
            employee.Birthdate = request.Birthdate;
            employee.Salary = request.Salary;
            employee.ChargeId = request.ChargeId;

            await _empleadoRepository.Update(employee);

            return employee.Id;
        }
    }
}