using Elastic.CommonSchema;
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
    public class SaldoController : ControllerBase
    {
        private readonly ILogger<SaldoController> _logger;
        private readonly IMediator _mediator;

        public SaldoController(ILogger<SaldoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatrimonioCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", command.ToJson());
            Serilog.Log.Information("PostClient method called: {command}", command.ToJson());
            await _mediator.Send(command);
            return Ok();
        }
    }
}