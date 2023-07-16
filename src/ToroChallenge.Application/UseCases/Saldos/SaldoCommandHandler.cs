using Microsoft.Extensions.Logging;
using ToroChallenge.Application.UseCases.Balances;
using ToroChallenge.Application.Utils;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoCommandHandler : ISaldoCommandHandler
    {
        private readonly IBalanceapplicationService _investimentoService;
        private readonly IApplicationResult _applicationResult;
        private readonly ILogger<SaldoCommandHandler> _logger;

        public SaldoCommandHandler(IBalanceapplicationService investimentoService, IApplicationResult applicationResult, ILogger<SaldoCommandHandler> logger)
        {
            _investimentoService = investimentoService;
            _applicationResult = applicationResult;
            _logger = logger;
        }

        public async Task<SaldoResponse> Handle(SaldoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            if (string.IsNullOrEmpty(request.LoginUsuario))
            {
                _applicationResult.Failed(DicionarioMessages.LoginUsuarioObrigatorio);
            }

            Balance saldo = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken).ConfigureAwait(true);

            if (saldo == null)
            {
                _applicationResult.NotFound(DicionarioMessages.SaldoNaoEncontrado);
            }
            SaldoResponse response = saldo;
            return response;
        }
    }
}
