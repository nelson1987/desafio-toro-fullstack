using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.ApplicationServices
{
    public interface IBalanceService
    {
        Task<Balance> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
