using KriniteWebShop.ProductCatalog.NoSQL.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Controllers;

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
    public async Task<ActionResult<IEnumerable<string>>> GetCategories()
    {
        IEnumerable<string> categories = await _categoryRepository.GetCategories();
        return Ok(categories);
    }
}
