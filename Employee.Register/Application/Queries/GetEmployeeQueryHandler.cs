using Employee.Register.Application.DTO;
using MediatR;

namespace Employee.Register.Application.Queries
{
    public class GetEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>
    {

    }
}
