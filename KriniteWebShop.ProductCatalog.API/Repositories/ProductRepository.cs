using KriniteWebShop.ProductCatalog.API.Data;
using KriniteWebShop.ProductCatalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.API.Repositories;

public class ProductRepository : IProductRepository
{
    private ProductDbContext _productDbContext { get; init; }

    public ProductRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        return await _productDbContext.Products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productDbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter)
    {
        return await _productDbContext.Products.Where(filter).AsNoTracking().ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _productDbContext.Products.AddAsync(product);
        await _productDbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateProduct(Guid id, RestProduct product)
    {
        if (!await _productDbContext.Products.AnyAsync(product => product.Id == id))
            return false;

        var updateResult = _productDbContext.Products.Update(product.ToProduct(id));
        bool result = updateResult.State == EntityState.Modified;

        if (result)
            await _productDbContext.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var deleteResult = await _productDbContext.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
        return deleteResult > 0;
    }
}
