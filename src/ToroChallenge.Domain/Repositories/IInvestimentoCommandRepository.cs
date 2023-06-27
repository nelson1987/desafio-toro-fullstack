using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Domain.Repositories
{
    public interface IInvestimentoCommandRepository
    {
        Task PostAsync(Investimento investimento, CancellationToken cancellationToken);
    }
}
