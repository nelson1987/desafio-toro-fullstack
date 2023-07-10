using Microsoft.AspNetCore.Mvc;
using ToroChallenge.Application.ApplicationServices;
using ToroChallenge.Application.UseCases.Contracts;
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
        private readonly IInvestimentoApplicationService _mediator;

        public BalanceController(ILogger<BalanceController> logger, IInvestimentoApplicationService mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste:");
            return StatusCode(200, "Teste");
        }

        [HttpPost]
        [ValidationActionFilter]
        public async Task<IActionResult> PostSaldoAsync([FromBody] PatrimonioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            //var response = _mediator.PostSaldoAsync(request.ToDocument());
            return StatusCode(200, "PostSaldoAsync");
        }

        [HttpPost("queue")]
        [ValidationActionFilter]
        public async Task<IActionResult> PostFilaAsync([FromBody] PatrimonioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            //var response = _mediator.PostFilaAsync(request.ToDocument());
            return StatusCode(200, "PostFilaAsync");
        }
    }
}