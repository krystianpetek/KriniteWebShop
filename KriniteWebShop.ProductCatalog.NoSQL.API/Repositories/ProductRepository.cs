using KriniteWebShop.ProductCatalog.NoSQL.API.Data;
using KriniteWebShop.ProductCatalog.NoSQL.API.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Repositories;

public class ProductRepository : IProductRepository
{
    private IProductDbContext _productDbContext { get; init; }

    public ProductRepository(IProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<Product> GetProductById(string id)
    {
        return await _productDbContext.Products.Find(product => product.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productDbContext.Products.Find(product => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter)
    {
        return await _productDbContext.Products.Find(filter).ToListAsync();

    }

    public async Task CreateProduct(Product product)
    {
        await _productDbContext.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await _productDbContext.Products.ReplaceOneAsync(filterProduct => filterProduct.Id == product.Id, product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var deleteResult = await _productDbContext.Products.DeleteOneAsync(product => product.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}
