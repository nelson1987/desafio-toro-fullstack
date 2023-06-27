using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Repositories
{
    public interface IBalanceQueryRepository
    {
        Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
