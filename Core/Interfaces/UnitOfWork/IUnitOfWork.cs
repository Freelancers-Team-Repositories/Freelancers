using Freelancers.Core.Entities;

namespace Freelancers.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IGenericRepository<ApplicationUser> Users { get; }
    Task<int> CompleteAsync();
}
