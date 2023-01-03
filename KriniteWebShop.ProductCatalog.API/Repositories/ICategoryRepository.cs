namespace KriniteWebShop.ProductCatalog.API.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<string>> GetCategories();
}
