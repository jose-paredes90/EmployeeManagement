using Employee.Register.Domain.Interfaces;

namespace Employee.Register.Application.Commands.Handlers
{
    public class DeleteEmployeeCommandhandler
    {
        private readonly IEmployeeRepository _empleadoRepository;

        public DeleteEmployeeCommandhandler(IEmployeeRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employeeExists = await _empleadoRepository.GetById(command.Id);
            if (employeeExists == null)
            {
                throw new Exception("Empleado no encontrado");
            }

            await _empleadoRepository.Delete(command.Id);
        }
    }
}
