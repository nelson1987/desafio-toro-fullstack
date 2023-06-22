using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Services
{
    public interface ISaldoService
    {
        Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
    public class SaldoService : ISaldoService
    {
        public Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
