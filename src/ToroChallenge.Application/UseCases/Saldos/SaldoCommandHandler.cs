using ToroChallenge.Application.ApplicationResults;
using ToroChallenge.Application.Resources;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Services;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoCommandHandler : ISaldoCommandHandler
    {
        private readonly ISaldoService _investimentoService;
        private readonly IApplicationResult _applicationResult;

        public SaldoCommandHandler(ISaldoService investimentoService, IApplicationResult applicationResult)
        {
            _investimentoService = investimentoService;
            _applicationResult = applicationResult;
        }

        public async Task<SaldoResponse> Handle(SaldoCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.LoginUsuario))
            {
                _applicationResult.Failed(DicionarioMessages.LoginUsuarioObrigatorio);
            }

            Saldo saldo = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken);

            if (saldo == null)
            {
                _applicationResult.NotFound(DicionarioMessages.SaldoNaoEncontrado);
            }

            return SaldoResponse.FromModel(saldo);
        }
    }
}
