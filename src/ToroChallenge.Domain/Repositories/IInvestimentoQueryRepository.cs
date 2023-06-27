using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Repositories
{
    public interface IInvestimentoQueryRepository
    {
        Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
