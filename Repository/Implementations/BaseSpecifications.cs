using Freelancers.Core.Interfaces.UnitOfWork;
using System.Linq.Expressions;

namespace Freelancers.Repository.Implementations;
public class BaseSpecifications<T> : ISpecifications<T> where T : class
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> IncludesCriteria { get; set; } = new List<Expression<Func<T, object>>>();
    public string OrderByDirection { get; set; } = Shared.Abstraction.Const.OrderBy.Ascending;
    public Expression<Func<T, object>> OrderBy { get; set; }
}
