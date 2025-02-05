using Employee.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Register.Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<EmployeeEntity> Employee { get; set; } = null!;
        public virtual DbSet<ChargeEntity> Charge { get; set; } = null!;


    }
}