using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Services
{
    public interface ISaldoService
    {
        Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
