namespace ToroChallenge.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
