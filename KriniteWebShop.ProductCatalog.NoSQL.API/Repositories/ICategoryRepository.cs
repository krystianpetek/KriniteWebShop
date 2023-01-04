namespace KriniteWebShop.ProductCatalog.NoSQL.API.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<string>> GetCategories();
}
