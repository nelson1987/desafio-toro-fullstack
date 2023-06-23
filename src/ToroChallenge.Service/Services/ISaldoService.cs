using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Domain.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly ISaldoQueryRepository _queryRepository;
        private readonly ISaldoCommandRepository _commandRepository;

        public SaldoService(ISaldoQueryRepository queryRepository, ISaldoCommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            return _queryRepository.GetAsync(loginUsuario, cancellationToken);
        }
    }
}
