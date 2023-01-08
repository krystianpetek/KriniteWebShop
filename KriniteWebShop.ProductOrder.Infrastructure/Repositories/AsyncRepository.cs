using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Domain.Common;
using KriniteWebShop.ProductOrder.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductOrder.Infrastructure.Repositories;
public class AsyncRepository<T> : IAsyncRepository<T> where T : EntityBase
{
    protected readonly OrderContext _orderContext;

    public AsyncRepository(OrderContext orderContext)
    {
        _orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        var collection = await _orderContext
            .Set<T>()
            .ToListAsync();

        return collection;
    }

    public virtual async Task<IReadOnlyCollection<T>> GetFilterAsync(Expression<Func<T, bool>> predicate)
    {
        List<T> collection = await _orderContext
            .Set<T>()
            .Where(predicate)
            .ToListAsync();

        return collection;
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
    {
        IQueryable<T> collection = _orderContext.Set<T>();
        if (disableTracking)
            collection.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(includeString))
            collection.Include(includeString);

        if (predicate != null)
            collection.Where(predicate);

        if (orderBy != null)
            collection = orderBy(collection);

        return (await collection.ToListAsync()).AsReadOnly();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetFilterWithIncludesAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
    {
        IQueryable<T> collection = _orderContext.Set<T>();
        if (disableTracking)
            collection.AsNoTracking();

        if (includes != null)
            collection = includes.Aggregate(collection, (element, include) => element.Include(include));

        if (predicate != null)
            collection.Where(predicate);

        if (orderBy != null)
            collection = orderBy(collection);

        return (await collection.ToListAsync()).AsReadOnly();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        T? entity = await _orderContext
            .Set<T>()
            .FirstOrDefaultAsync(entityId => entityId.Id == id);

        return entity;
    }
    public virtual async Task<T> AddAsync(T entity)
    {
        await _orderContext
            .Set<T>()
            .AddAsync(entity);

        await _orderContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _orderContext.Entry(entity).State = EntityState.Modified;
        await _orderContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _orderContext
            .Set<T>()
            .Remove(entity);

        await _orderContext.SaveChangesAsync();
    }
}
