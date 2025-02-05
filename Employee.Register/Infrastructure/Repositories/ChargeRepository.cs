using Employee.Register.Domain.Entities;
using Employee.Register.Domain.Interfaces;
using Employee.Register.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Employee.Register.Infrastructure.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly AppDbContext context;

        public ChargeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ChargeEntity>> Get()
        {
            return await context.Charge.ToListAsync();
        }
    }
}
