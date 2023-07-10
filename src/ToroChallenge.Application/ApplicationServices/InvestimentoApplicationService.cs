using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToroChallenge.Application.UseCases.ContaAberta;
using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Patrimonios;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.ApplicationServices
{
    public class InvestimentoApplicationService : IInvestimentoApplicationService
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publisher;
        private readonly ILogger<InvestimentoApplicationService> _logger;

        public InvestimentoApplicationService(IMediator mediator, IPublishEndpoint publisher, ILogger<InvestimentoApplicationService> logger)
        {
            _mediator = mediator;
            _publisher = publisher;
            _logger = logger;
        }

        public async Task<PatrimonioResponse> PostSaldoAsync([FromBody] PatrimonioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            var invest = _mediator.Send(new InvestimentoCommand(), cancellationToken);
            await _publisher.Publish(new ContaAbertaEvent() { Numero = "11122233351" }, cancellationToken);
            var alteracao = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Teste: {command}", request.ToJson());
            return (PatrimonioResponse)request;
        }

        public async Task<PatrimonioResponse> PostFilaAsync([FromBody] PatrimonioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            await _publisher.Publish(new ContaAbertaEvent() { Numero = "11122233351" }, cancellationToken);
            _logger.LogInformation("Teste: {command}", request.ToJson());
            return (PatrimonioResponse)request;
        }
    }
}
