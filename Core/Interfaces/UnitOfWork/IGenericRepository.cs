
namespace Freelancers.Core.Interfaces.UnitOfWork;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(ISpecifications<T> spec);


    public Task<T?> GetByIdAsync(ISpecifications<T> spec);
    public Task<T?> GetByIdAsync(int id);
    public Task<T?> GetByIdAsync(string id);


    Task AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
}
