using Microsoft.Extensions.Logging;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Application.ApplicationServices
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceQueryRepository _queryRepository;
        private readonly IBalanceCommandRepository _commandRepository;
        private readonly ILogger<BalanceService> _logger;

        public BalanceService(IBalanceQueryRepository queryRepository, IBalanceCommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", loginUsuario);
            return _queryRepository.GetAsync(loginUsuario, cancellationToken);
        }
    }
}
