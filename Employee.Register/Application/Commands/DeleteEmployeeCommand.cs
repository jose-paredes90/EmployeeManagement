using MediatR;

namespace Employee.Register.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
