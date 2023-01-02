using KriniteWebShop.Catalog.API.Data.SqlContext;
using KriniteWebShop.Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KriniteWebShop.Catalog.API.Repositories;

public class ProductRepository : IProductRepository
{
    private ProductDbContext _productDbContext { get; init; }

    public ProductRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        return await _productDbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<IReadOnlyCollection<Product>> GetProducts()
    {
        return await _productDbContext.Products.ToListAsync();
    }

    public async Task<IReadOnlyCollection<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter)
    {
        return await _productDbContext.Products.Where(filter).ToListAsync();
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
