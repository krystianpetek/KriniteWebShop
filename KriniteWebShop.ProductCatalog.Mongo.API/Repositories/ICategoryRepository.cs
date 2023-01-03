namespace KriniteWebShop.ProductCatalog.Mongo.API.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<string>> GetCategories();
}
