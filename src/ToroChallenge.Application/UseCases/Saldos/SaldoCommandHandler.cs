using ToroChallenge.Domain.Services;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoCommandHandler : ISaldoCommandHandler
    {
        private readonly ISaldoService _investimentoService;

        public SaldoCommandHandler(ISaldoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        public async Task<SaldoResponse> Handle(SaldoCommand request, CancellationToken cancellationToken)
        {
            var saldo = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken);
            return SaldoResponse.FromModel(saldo);
        }
    }
}
