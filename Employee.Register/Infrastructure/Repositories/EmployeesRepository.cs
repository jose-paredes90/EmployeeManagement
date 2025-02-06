using Employee.Register.Domain.Entities;
using Employee.Register.Domain.Interfaces;
using Employee.Register.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Employee.Register.Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;

        public EmployeesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeEntity>> Get()
        {

            return await _context.Employee
                .Include(e => e.Charge)
                .ToListAsync();
        }

        public async Task Create(EmployeeEntity empleado)
        {
            await _context.Employee.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task Update(EmployeeEntity empleado)
        {

            _context.Employee.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(EmployeeEntity employee)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeEntity?> GetById(int id)
        {
            return await _context.Employee
                .Include(e => e.Charge)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
