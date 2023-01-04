using KriniteWebShop.ProductCatalog.API.Data;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.ProductCatalog.API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ProductDbContext _productDbContext { get; init; }

    public CategoryRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<IEnumerable<string>> GetCategories()
    {
        IEnumerable<string> categories = await _productDbContext.Products.AsNoTracking().Select(product => product.Category).Distinct().ToListAsync();
        return categories;
    }
}
