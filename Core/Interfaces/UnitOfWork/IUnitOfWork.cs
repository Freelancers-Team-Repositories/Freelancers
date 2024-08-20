namespace Freelancers.Core.Interfaces.UnitOfWork;
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    public IGenericRepository<T> Repository<T>() where T : class;
    Task<int> CompleteAsync();
}