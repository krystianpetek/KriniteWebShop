namespace KriniteWebShop.ProductCatalog.Mongo.API.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<string>> GetCategories();
}
