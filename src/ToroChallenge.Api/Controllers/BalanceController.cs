using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToroChallenge.Application.ApplicationServices;
using ToroChallenge.Application.UseCases.Contracts;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [SwaggerTag("Create, read, update and delete Products")]
    public class BalanceController : ControllerBase
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IInvestimentoApplicationService _mediator;

        public BalanceController(ILogger<BalanceController> logger, IInvestimentoApplicationService mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet]
        [SwaggerOperation(Description = "Description", 
            OperationId = "OperationId",
            Summary = "Gets the home page.",
            Tags = new[] { "Home" }
        )]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BalanceController), 400)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste:");
            await _mediator.PostFilaAsync(new Application.UseCases.Patrimonios.PatrimonioCommand() { 
            }, cancellationToken);
            return StatusCode(200, "Teste");
        }
        /*
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
        public async Task<IActionResult> PostFilaAsync([FromBody, SwaggerParameter("Search keywords", Required = true)] PatrimonioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            //var response = _mediator.PostFilaAsync(request.ToDocument());
            return StatusCode(200, "PostFilaAsync");
        }
        */
    }
}