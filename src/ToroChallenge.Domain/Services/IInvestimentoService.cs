using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Services
{
    public interface IInvestimentoService
    {
        Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken);

        Task PostAsync(Investimento investimento, CancellationToken cancellationToken);
    }
}
