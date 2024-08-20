using System.Linq.Expressions;

namespace Freelancers.Core.Interfaces.UnitOfWork;

public interface ISpecifications<T>
{
    Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> IncludesCriteria { get; set; }
    Expression<Func<T, object>> OrderBy { get; set; }
    string OrderByDirection { get; set; }
}