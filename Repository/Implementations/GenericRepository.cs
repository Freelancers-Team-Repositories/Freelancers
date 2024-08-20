using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Repository.Implementations;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync(ISpecifications<T> spec)
      => await SpecificationsEvaluator<T>.GetQuery(_context.Set<T>(), spec).ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<T?> GetByIdAsync(string id)
      => await _context.Set<T>().FindAsync(id);

    public async Task<T?> GetByIdAsync(ISpecifications<T> spec)
        => await SpecificationsEvaluator<T>.GetQuery(_context.Set<T>(), spec).FirstOrDefaultAsync();

    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public void DeleteAsync(T entity)
        => _context.Remove(entity);

    public void UpdateAsync(T entity)
        => _context.Update(entity);
}
