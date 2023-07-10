using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.UseCases.Balances
{
    public interface IInvestimentoService
    {
        Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken);

        Task PostAsync(Investimento investimento, CancellationToken cancellationToken);
    }
}
