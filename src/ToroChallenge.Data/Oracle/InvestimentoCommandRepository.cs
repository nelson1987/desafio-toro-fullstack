using Microsoft.Extensions.Logging;
using ToroChallenge.Application.Utils;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class InvestimentoCommandRepository : IInvestimentoCommandRepository
    {
        private readonly ILogger<InvestimentoCommandRepository> _logger;

        public InvestimentoCommandRepository(ILogger<InvestimentoCommandRepository> logger)
        {
            _logger = logger;
        }

        public Task PostAsync(Investimento investimento, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", investimento.ToJson());
            throw new NotImplementedException();
        }
    }
}
