using KriniteWebShop.Catalog.API.Data.SqlContext;
using KriniteWebShop.Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.Catalog.API.Repositories;

public class ProductRepository : IProductRepository
{
    private ProductDbContext _productDbContext { get; init; }

    public ProductRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<Product?> GetProduct(Guid id)
    {
        return await _productDbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
    }

    public IAsyncEnumerable<Product> GetProducts()
    {
        return _productDbContext.Products.AsAsyncEnumerable();
    }
    public IAsyncEnumerable<Product> GetProductsByName(string name)
    {
        return _productDbContext.Products.Where(product => product.Category == name).AsAsyncEnumerable();
    }

    public IAsyncEnumerable<Product> GetProductsByCategory(string categoryName)
    {
        return _productDbContext.Products.Where(product => product.Category == categoryName).AsAsyncEnumerable();
    }

    public async Task CreateProduct(Product product)
    {
        await _productDbContext.Products.AddAsync(product);
        await _productDbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = _productDbContext.Products.Update(product);
        await _productDbContext.SaveChangesAsync();

        return updateResult.State == EntityState.Modified;
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var deleteResult = await _productDbContext.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
        return deleteResult > 0;
    }
}
