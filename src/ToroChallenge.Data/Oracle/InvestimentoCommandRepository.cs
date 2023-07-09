using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.Oracle
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
