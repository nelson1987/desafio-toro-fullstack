using Microsoft.Extensions.Logging;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class SaldoQueryRepository : IBalanceQueryRepository
    {
        private readonly ILogger<SaldoQueryRepository> _logger;

        public SaldoQueryRepository(ILogger<SaldoQueryRepository> logger)
        {
            _logger = logger;
        }

        public Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", loginUsuario);
            throw new NotImplementedException();
        }
    }
}
