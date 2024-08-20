using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Shared.Abstraction.Const;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Repository.Implementations;
public class SpecificationsEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
    {
        var query = inputQuery;

        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        if (spec.OrderBy != null)
        {
            if (spec.OrderByDirection == OrderBy.Ascending)
                query = query.OrderBy(spec.OrderBy);
            else
                query = query.OrderByDescending(spec.OrderBy);
        }

        query = spec.IncludesCriteria.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

        return query;
    }
}
