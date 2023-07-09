using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventConsumer :
        IConsumer<ContaAbertaEvent>
    {
        readonly ILogger<ContaAbertaEventConsumer> _logger;
        readonly IMediator _mediator;

        public ContaAbertaEventConsumer(ILogger<ContaAbertaEventConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<ContaAbertaEvent> context)
        {
            try
            {
                var resultado = await _mediator.Send(new ContaAbertaEventSync()
                {
                    Numero = context.Message.Numero,
                    Id = context.Message.Id,
                    Agencia = context.Message.Agencia,
                    IdCliente = context.Message.IdCliente,
                    Tipo = context.Message.Tipo
                });
                _logger.LogInformation("Value: {0}", context.Message.ToJson());
            }
            catch (Exception ex)
            {
                throw new Exception($"Problema ao realizar uma inserção: {ex.Message}");
            }
        }
    }
}