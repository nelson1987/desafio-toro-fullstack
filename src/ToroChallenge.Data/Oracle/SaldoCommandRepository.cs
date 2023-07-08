using Microsoft.Extensions.Logging;
using ToroChallenge.Application.Utils;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.Oracle
{
    public class SaldoCommandRepository : IBalanceCommandRepository
    {
        private readonly ILogger<SaldoCommandRepository> _logger;

        public SaldoCommandRepository(ILogger<SaldoCommandRepository> logger)
        {
            _logger = logger;
        }

        public Task PostAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", loginUsuario.ToJson());
            throw new NotImplementedException();
        }
    }
}
