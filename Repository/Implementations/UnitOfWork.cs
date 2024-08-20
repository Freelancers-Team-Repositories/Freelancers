using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Repository.Persistence;
using System.Collections.Concurrent;

namespace Freelancers.Repository.Implementations;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly ConcurrentDictionary<string, object> _repositories;

    public UnitOfWork(ApplicationDbContext storeContext)
    {
        _context = storeContext;
        _repositories = new ConcurrentDictionary<string, object>();
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var key = typeof(T).Name;

        return (IGenericRepository<T>)_repositories.GetOrAdd(key, _ => new GenericRepository<T>(_context));
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
}