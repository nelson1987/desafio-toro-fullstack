namespace ToroChallenge.Domain.Repositories
{
    public interface IBalanceCommandRepository
    {
        Task PostAsync(string loginUsuario, CancellationToken cancellationToken);
    }
}
