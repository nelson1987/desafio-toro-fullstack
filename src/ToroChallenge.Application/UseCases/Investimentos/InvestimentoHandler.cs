using ToroChallenge.Application.ApplicationResults;
using ToroChallenge.Application.Resources;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Services;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoHandler : IInvestimentoHandler
    {
        private readonly IInvestimentoService _investimentoService;
        private readonly IApplicationResult _applicationResult;

        public InvestimentoHandler(IInvestimentoService investimentoService, IApplicationResult applicationResult)
        {
            _investimentoService = investimentoService;
            _applicationResult = applicationResult;
        }

        public async Task<InvestimentoResponse[]> Handle(InvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.LoginUsuario))
            {
                _applicationResult.Failed(DicionarioMessages.LoginUsuarioObrigatorio);
            }

            Investimento[] investimentos = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken);

            if (investimentos == null)
            {
                _applicationResult.NotFound(DicionarioMessages.NenhumInvestimentoFoiEncontrado);
            }

            return investimentos.Select(x => InvestimentoResponse.FromModel(x)).ToArray();
        }
    }
}
