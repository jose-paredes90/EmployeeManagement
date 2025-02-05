using Employee.Register.Application.DTO;
using Employee.Register.Domain.Interfaces;

namespace Employee.Register.Application.Queries.Handlers
{
    public class GetChargeQueryHandler
    {
        private readonly IChargeRepository _chargeRepository;

        public GetChargeQueryHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<IEnumerable<ChargeDto>> Handle(GetChargeQuery request, CancellationToken cancellationToken)
        {
            var permissionType = await _chargeRepository.Get();
            return permissionType?.Select(item => new ChargeDto
            {
                Id = item.Id,
                Nombre = item.Name,
            }).ToList() ?? new List<ChargeDto>();
        }
    }
}
