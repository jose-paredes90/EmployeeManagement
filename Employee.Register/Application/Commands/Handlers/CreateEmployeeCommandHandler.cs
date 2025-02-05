using Employee.Register.Application.DTO;
using Employee.Register.Domain.Entities;
using Employee.Register.Domain.Interfaces;

namespace Employee.Register.Application.Commands.Handlers
{
    public class CreateEmployeeCommandHandler
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<EmployeeEntity> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                AFP = request.AFP,
                Birthdate = request.Birthdate,
                ChargeId = request.ChargeId,
                Hiredate = request.Hiredate,
                Salary = request.Salary,
            };

            await _empleadoRepository.Create(employee);
            return employee;
        }
    }
}
