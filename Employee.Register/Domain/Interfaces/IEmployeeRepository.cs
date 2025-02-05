using Employee.Register.Domain.Entities;

namespace Employee.Register.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> Get();
        Task Create(EmployeeEntity employee);
        Task Update(EmployeeEntity employee);
        Task<EmployeeEntity> GetById(int id);
        Task Delete(int id);
    }
}
