using Employee.Register.Application.DTO;
using Employee.Register.Domain.Interfaces;
using MediatR;

namespace Employee.Register.Application.Queries.Handlers
{
    public class GetChargeQueryHandler : IRequestHandler<GetChargesQuery, IEnumerable<ChargeDto>>
    {
        private readonly IChargeRepository _chargeRepository;

        public GetChargeQueryHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }


        public async Task<IEnumerable<ChargeDto>> Handle(GetChargesQuery request, CancellationToken cancellationToken)
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