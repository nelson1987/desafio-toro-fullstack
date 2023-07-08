using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToroChallenge.Application.FilterAttributes;
using ToroChallenge.Application.UseCases.Patrimonios;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BalanceController : ControllerBase
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IMediator _mediator;

        public BalanceController(ILogger<BalanceController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ValidationActionFilter]
        public async Task<IActionResult> PostSaldoAsync([FromBody] PatrimonioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            return await _mediator.Send(request, cancellationToken).ConfigureAwait(true);
            //return Ok();
        }
    }
}