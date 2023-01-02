namespace KriniteWebShop.Catalog.API.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<string>> GetCategories();
}
