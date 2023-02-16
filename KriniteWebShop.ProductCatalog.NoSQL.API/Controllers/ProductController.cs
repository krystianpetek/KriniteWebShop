using KriniteWebShop.ProductCatalog.NoSQL.API.Entities;
using KriniteWebShop.ProductCatalog.NoSQL.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Controllers;

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
        _logger.LogInformation($"Invoked method {nameof(GetProducts)} in {nameof(ProductController)}");

        IEnumerable<Product> products = await _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(typeof(string), "text/plain")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        _logger.LogInformation($"Invoked method {nameof(GetProductById)} for ID: {id} in {nameof(ProductController)}");

        Product product = await _productRepository.GetProductById(id);
        if (product is null)
        {
            _logger.LogError($"Product with id: {id}, not found.");
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("[action]/{name}", Name = "GetProductsByName")]
    [Consumes(typeof(string), "text/plain")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string name)
    {
        _logger.LogInformation($"Invoked method {nameof(GetProductsByName)} for product name: {name} in {nameof(ProductController)}");

        IEnumerable<Product> products = await _productRepository.GetProductsWithFilter(product => product.Name.Contains(name));
        return Ok(products);
    }

    [HttpGet("[action]/{category}", Name = "GetProductsByCategory")]
    [Consumes(typeof(string), "text/plain")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
    {
        _logger.LogInformation($"Invoked method {nameof(GetProductsByCategory)} for product with category: {category} in {nameof(ProductController)}");

        IEnumerable<Product> products = await _productRepository.GetProductsWithFilter(product => product.Category.Contains(category));
        return Ok(products);
    }

    [HttpPost]
    [Consumes(typeof(RestProduct), "application/json")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Product>> CreateProduct(RestProduct createProduct)
    {
        _logger.LogInformation($"Invoked method {nameof(CreateProduct)} in {nameof(ProductController)}");
        
        if (createProduct is null)
        {
            _logger.LogError($"Product passed for create is null or empty.");
            return NotFound();
        }

        Product product = createProduct.ToProduct();
        await _productRepository.CreateProduct(product);

        return CreatedAtAction(nameof(GetProductById), new { product.Id }, product);
    }

    [HttpPut("{id}")]
    [Consumes(typeof(Product), "application/json")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateProduct(string id, RestProduct product)
    {
        _logger.LogInformation($"Invoked method {nameof(UpdateProduct)} for product with ID: {id} in {nameof(ProductController)}");

        if (product is null || string.IsNullOrWhiteSpace(id))
        {
            _logger.LogError($"Product passed for update is null or empty.");
            return NotFound();
        }

        bool updateResult = await _productRepository.UpdateProduct(id, product);
        return Ok(updateResult);
    }

    [HttpDelete("{id}")]
    [Consumes(typeof(string), "application/json")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        _logger.LogInformation($"Invoked method {nameof(DeleteProduct)} for product with ID: {id} in {nameof(ProductController)}");
        
        if(string.IsNullOrEmpty(id))
        {
            _logger.LogError($"Product passed for update is null or empty.");
            return NotFound();
        }

        bool deleteResult = await _productRepository.DeleteProduct(id);
        return Ok(deleteResult);
    }

    [HttpGet("Categories")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<string>>> GetCategories()
    {
        _logger.LogInformation($"Invoked method {nameof(GetCategories)} in {nameof(ProductController)}");

        IEnumerable<string> categories = await _productRepository.GetProductCategories();
        return Ok(categories);
    }
}
