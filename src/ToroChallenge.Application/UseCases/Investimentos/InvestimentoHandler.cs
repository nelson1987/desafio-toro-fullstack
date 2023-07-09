using Microsoft.Extensions.Logging;
using ToroChallenge.Application.Utils;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Services;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoHandler : IInvestimentoHandler
    {
        private readonly ILogger<InvestimentoHandler> _logger;
        private readonly IInvestimentoService _investimentoService;
        private readonly IApplicationResult _applicationResult;

        public InvestimentoHandler(IInvestimentoService investimentoService, IApplicationResult applicationResult, ILogger<InvestimentoHandler> logger)
        {
            _investimentoService = investimentoService;
            _applicationResult = applicationResult;
            _logger = logger;
        }

        [ValidationActionFilter]
        public async Task<InvestimentoResponse[]> Handle(InvestimentoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {request}", request.ToJson());

            await GetValidation(request, cancellationToken);

            Investimento[] investimentos = await _investimentoService.GetAsync(request.LoginUsuario, cancellationToken).ConfigureAwait(true);

            if (investimentos == null)
            {
                _applicationResult.NotFound(DicionarioMessages.NenhumInvestimentoFoiEncontrado);
            }

            return investimentos.Select(x => InvestimentoResponse.FromModel(x)).ToArray();
        }
        public async Task GetValidation(InvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (request.HasError(out IDictionary<string, string[]> errors))
            {
                _applicationResult.Failed(errors);
            }

            if (string.IsNullOrEmpty(request.LoginUsuario))
            {
                _applicationResult.Failed(DicionarioMessages.LoginUsuarioObrigatorio);
            }
        }
    }
}
