using Employee.Register.Domain.Interfaces;
using MediatR;
using static Employee.Register.Middleware.Exceptions.BasicExceptions;

namespace Employee.Register.Application.Commands.Handlers
{
    public class DeleteEmployeeCommandhandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public DeleteEmployeeCommandhandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _empleadoRepository.GetById(command.Id);
            if (employee == null)
                throw new NotFoundException("Empleado no encontrado");

            await _empleadoRepository.Delete(employee);
        }
    }
}
