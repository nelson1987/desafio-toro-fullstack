using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> PostSaldoAsync([FromBody] PatrimonioCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", command.ToJson());
            await _mediator.Send(command, cancellationToken).ConfigureAwait(true);
            return Ok();
        }
    }
}