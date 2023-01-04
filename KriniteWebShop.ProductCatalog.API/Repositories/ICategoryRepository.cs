namespace KriniteWebShop.ProductCatalog.API.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<string>> GetCategories();
}
