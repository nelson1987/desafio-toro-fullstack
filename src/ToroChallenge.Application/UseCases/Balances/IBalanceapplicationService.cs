using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.UseCases.Balances
{
    public interface IBalanceapplicationService
    {
        Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
