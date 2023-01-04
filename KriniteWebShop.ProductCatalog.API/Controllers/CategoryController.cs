using KriniteWebShop.ProductCatalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductCatalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    [HttpGet]
    public async Task<IEnumerable<string>> GetCategories()
    {
        return await _categoryRepository.GetCategories();
    }
}
