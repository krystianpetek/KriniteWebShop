using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KriniteWebShop.ProductCatalog.API.Entities;
using KriniteWebShop.ProductCatalog.API.Repositories;

namespace KriniteWebShop.ProductCatalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductController> _logger;

    public ProductController(
        IProductRepository productRepository,
        ILogger<ProductController> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        IEnumerable<Product> products = await _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(typeof(Guid), "application/json")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> GetProductById(Guid id)
    {
        Product product = await _productRepository.GetProductById(id);
        if (product == null)
        {
            _logger.LogError($"Product with id: {id}, not found.");
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet( "[action]/{name}", Name = "GetProductByName")]
    [Consumes(typeof(string), "application/json")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
    {
        IEnumerable<Product> products = await _productRepository.GetProductsWithFilter(product => product.Name.Contains(name));
        return Ok(products);
    }

    [HttpGet( "[action]/{category}", Name = "GetProductByCategory")]
    [Consumes(typeof(string), "application/json")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
    {
        IEnumerable<Product> products = await _productRepository.GetProductsWithFilter(product => product.Category.Contains(category));
        return Ok(products);
    }

    [HttpPost]
    [Consumes(typeof(RestProduct), "application/json")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    public async Task<ActionResult<Product>> CreateProduct(RestProduct createProduct)
    {
        Product product = createProduct.ToProduct();
        await _productRepository.CreateProduct(product);

        return CreatedAtAction("GetProductById", new { product.Id }, product);
    }

    [HttpPut("{id}")]
    [Consumes(typeof(Product), "application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateProduct(Guid id, RestProduct product)
    {
        bool updateResult = await _productRepository.UpdateProduct(id, product);
        return Ok(updateResult);
    }

    [HttpDelete("{id}")]
    [Consumes(typeof(Guid), "application/json")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        bool deleteResult = await _productRepository.DeleteProduct(id);
        return Ok(deleteResult);
    }
}
