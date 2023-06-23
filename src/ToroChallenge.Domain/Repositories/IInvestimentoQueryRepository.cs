using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Repositories
{
    public interface IInvestimentoQueryRepository
    {
        Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
    public interface IInvestimentoCommandRepository
    {
        Task PostAsync(string loginUsuario, CancellationToken cancellationToken);
    }
    public interface ISaldoQueryRepository
    {
        Task<Saldo> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
    public interface ISaldoCommandRepository
    {
        Task PostAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
