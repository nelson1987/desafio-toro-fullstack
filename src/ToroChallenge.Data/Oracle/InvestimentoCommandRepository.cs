using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class InvestimentoCommandRepository : IInvestimentoCommandRepository
    {
        public Task PostAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class SaldoCommandRepository : ISaldoCommandRepository
    {
        public Task PostAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
