using Employee.Register.Application.DTO;
using Employee.Register.Domain.Interfaces;
using MediatR;

namespace Employee.Register.Application.Queries.Handlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public GetEmployeeQueryHandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
        {
            var employees = await _empleadoRepository.Get();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                AFP = e.AFP,
                Charge = new ChargeDto()
                {
                    Id = e.Charge.Id,
                    Nombre = e.Charge.Name,
                },
                Hiredate = e.Hiredate,
                Lastname = e.Lastname,
                Salary = e.Salary,
                Birthdate = e.Birthdate,
            });
        }
    }
}