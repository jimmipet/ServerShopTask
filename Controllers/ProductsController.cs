using Microsoft.AspNetCore.Mvc;
using ServerShopTask.Services;

namespace ServerShopTask.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductsController(ProductService productService) : ControllerBase
    {
        private readonly ProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetProductsAsync();
            return (products == null || !products.Any()) ? NotFound() : Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
