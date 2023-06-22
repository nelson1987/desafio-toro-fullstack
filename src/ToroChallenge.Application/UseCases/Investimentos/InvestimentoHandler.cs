using ToroChallenge.Domain.Services;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoHandler : IInvestimentoHandler
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoHandler(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        public async Task<InvestimentoResponse[]> Handle(InvestimentoCommand request, CancellationToken cancellationToken)
        {
            var investimentos = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken);
            return investimentos.Select(x => InvestimentoResponse.FromModel(x)).ToArray();
        }
    }
}
