using System.Reflection;
using Employee.Register.Domain.Interfaces;
using Employee.Register.Infrastructure.DataContext;
using Employee.Register.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employee.Register
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEmployeeDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEmployeeRepository, EmployeesRepository>();
            services.AddScoped<IChargeRepository, ChargeRepository>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
