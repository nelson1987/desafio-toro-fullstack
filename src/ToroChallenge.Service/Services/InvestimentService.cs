using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;
using ToroChallenge.Domain.Services;

namespace ToroChallenge.Service.Services
{
    public class InvestimentService : IInvestimentoService
    {
        private readonly IInvestimentoQueryRepository _queryRepository;
        private readonly IInvestimentoCommandRepository _commandRepository;

        public InvestimentService(IInvestimentoQueryRepository queryRepository, IInvestimentoCommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAsync(loginUsuario, cancellationToken).ConfigureAwait(false);
        }

        public async Task PostAsync(Investimento investimento, CancellationToken cancellationToken)
        {
            await _commandRepository.PostAsync(investimento, cancellationToken).ConfigureAwait(true);
        }
    }
}
