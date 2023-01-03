using KriniteWebShop.ProductCatalog.Mongo.API.Data;
using MongoDB.Driver;

namespace KriniteWebShop.ProductCatalog.Mongo.API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private IProductDbContext _productDbContext { get; init; }

    public CategoryRepository(IProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<IReadOnlyCollection<string>> GetCategories()
    {
        var categories = _productDbContext.Products.AsQueryable().Select(x => x.Category).Distinct().ToList();
        return await Task.FromResult(categories);
    }
}
