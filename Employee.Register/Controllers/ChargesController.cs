using Employee.Register.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargesController : ControllerBase
    {
        private IMediator mediator;

        public ChargesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetChargesQuery();
            var chareges = await mediator.Send(query, cancellationToken);
            return Ok(chareges);
        }

    }
}
