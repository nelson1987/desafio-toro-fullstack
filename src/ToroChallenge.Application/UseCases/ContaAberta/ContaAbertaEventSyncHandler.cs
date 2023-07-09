using MediatR;
using Microsoft.Extensions.Logging;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventSyncHandler : IRequestHandler<ContaAbertaEventSync, ContaAbertaEventSyncResponse>
    {
        readonly ILogger<ContaAbertaEventSyncHandler> _logger;

        public ContaAbertaEventSyncHandler(ILogger<ContaAbertaEventSyncHandler> logger)
        {
            _logger = logger;
        }

        public async Task<ContaAbertaEventSyncResponse> Handle(ContaAbertaEventSync request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Value: {0}", request.ToJson());
            return new ContaAbertaEventSyncResponse();
        }
    }
}