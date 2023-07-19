using KriniteWebShop.Order.Domain.Common;
using System.Linq.Expressions;

namespace KriniteWebShop.Order.Domain.Repository;
public interface IAsyncRepository<T> where T : EntityBase
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> GetFilterAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyCollection<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyCollection<T>> GetFilterWithIncludesAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true);
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
