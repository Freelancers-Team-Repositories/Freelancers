using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Repository.Persistence;

namespace Freelancers.Repository.Implementations;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Users = new GenericRepository<ApplicationUser>(_context);
    }


    public IGenericRepository<ApplicationUser> Users { get; private set; }

    public Task<int> CompleteAsync()
        => _context.SaveChangesAsync();


    public void Dispose() => _context.Dispose();

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

}
