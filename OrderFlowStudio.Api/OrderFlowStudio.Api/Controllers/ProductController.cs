using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.Product_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // CREATE
        [HttpPost("api/product")]
        public ActionResult CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            var product = ProductMapper.SerializeProductCreateDtoToProduct(productCreateDto);
            var serviceResponse = _productService.AddProduct(product);
            return Ok(serviceResponse);
        }

        // READ
        [HttpGet("api/product")]
        public ActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            var productsReadDto = ProductMapper.SerializeProductListToProductReadDtoList(products);
            return Ok(productsReadDto);
        }

        // READ
        [HttpGet("api/product/{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _productService.GetProductByid(id);
            var productReadDto = ProductMapper.SerializeProductToProductReadDto(product);
            return Ok(productReadDto);
        }

        // UPDATE
        [HttpPatch("api/product")]
        public ActionResult UpdateProduct([FromBody] ProductReadDto productReadDto)
        {
            var product = ProductMapper.SerializeProductReadDtoToProduct(productReadDto);
            var serviceResponse = _productService.UpdateProduct(product);
            return Ok(serviceResponse);

        }

        // DELETE
        // No need to code this functionality here !
    }
}
