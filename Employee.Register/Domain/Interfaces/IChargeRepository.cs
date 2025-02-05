using Employee.Register.Domain.Entities;

namespace Employee.Register.Domain.Interfaces
{
    public interface IChargeRepository
    {
        Task<IEnumerable<ChargeEntity>> Get();
    }
}
