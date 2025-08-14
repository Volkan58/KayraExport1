using KayraWebAPI.Dtos;
using KayraWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetProduct()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving products.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetProductById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the product.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<GetProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                if (createProductDto == null)
                {
                    return BadRequest("Invalid product data.");
                }
                var createdProduct = await _productService.CreateProductAsync(createProductDto);
                return Ok(createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the product.");
            }
        }
        [HttpPut]
        public async Task<ActionResult<UpdateProductDto>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                if (updateProductDto == null)
                {
                    return BadRequest("Invalid product data.");
                }
                var updatedProduct = await _productService.UpdateProductAsync(updateProductDto);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok(updatedProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(Guid id, bool permanent = false)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id, permanent);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the product.");
            }
        }
    }
}
