using Employee.Register.Domain.Interfaces;
using System.Security;

namespace Employee.Register.Application.Commands.Handlers
{
    public class UpdateEmployeeCommandHandler
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _empleadoRepository.GetById(request.Id);
            if (employee == null) throw new Exception("Permission not found");

            employee.Hiredate = DateTime.Now;
            employee.Name = request.Name;
            employee.Lastname = request.Lastname;
            employee.AFP = request.AFP;
            employee.Birthdate = DateTime.Now;
            employee.Salary = request.Salary;
            employee.ChargeId = request.ChargeId;

            await _empleadoRepository.Update(employee);

            return employee.Id;
        }
    }
}
