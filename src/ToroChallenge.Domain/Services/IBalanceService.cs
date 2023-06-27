using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Services
{
    public interface IBalanceService
    {
        Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
