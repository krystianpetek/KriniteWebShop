using KriniteWebShop.Catalog.API.Data.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.Catalog.API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ProductDbContext _productDbContext { get; init; }

    public CategoryRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<IReadOnlyCollection<string>> GetCategories()
    {
        IReadOnlyCollection<string> categories = await _productDbContext.Products.Select(product => product.Category).Distinct().ToListAsync();
        return categories;
    }
}
