using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Domain.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private readonly IInvestimentoQueryRepository _queryRepository;
        private readonly IInvestimentoCommandRepository _commandRepository;

        public InvestimentoService(IInvestimentoQueryRepository queryRepository, IInvestimentoCommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAsync(loginUsuario, cancellationToken);
        }
    }
}
