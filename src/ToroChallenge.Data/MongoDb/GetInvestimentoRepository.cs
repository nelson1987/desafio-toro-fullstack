using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class InvestimentoQueryRepository : IInvestimentoQueryRepository
    {
        public Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class SaldoQueryRepository : ISaldoQueryRepository
    {
        public Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
