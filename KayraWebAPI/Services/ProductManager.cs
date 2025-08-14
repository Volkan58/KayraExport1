using KayraWebAPI.Dtos;
using KayraWebAPI.Models;
using KayraWebAPI.Repository;

namespace KayraWebAPI.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product()
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                StockQuantity = createProductDto.StockQuantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var createdProduct = await _productRepository.AddProductAsync(product);
            return new CreateProductDto
            {
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                StockQuantity = createdProduct.StockQuantity,
                CreatedAt = createdProduct.CreatedAt,
                UpdatedAt = createdProduct.UpdatedAt
            };
        }

        public async Task<bool> DeleteProductAsync(Guid id, bool permanent)
        {
            return await _productRepository.DeleteProductAsync(id, permanent);
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
        {
          var products=await _productRepository.GetAllProductsAsync();
            return products.Select(p => new GetProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });
        }

        public async Task<GetProductDto> GetProductByIdAsync(Guid id)
        {
            var product=await _productRepository.GetProductByIdAsync(id);
            if (product != null)
            {
                return new GetProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UpdateProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var existingProduct =await _productRepository.GetProductByIdAsync(updateProductDto.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updateProductDto.Name;
                existingProduct.Description = updateProductDto.Description;
                existingProduct.Price = updateProductDto.Price;
                existingProduct.StockQuantity = updateProductDto.StockQuantity;
                existingProduct.UpdatedAt = DateTime.UtcNow;
                var updatedProduct =await _productRepository.UpdateProductAsync(existingProduct);
                return new UpdateProductDto
                {
                    Id = updatedProduct.Id,
                    Name = updatedProduct.Name,
                    Description = updatedProduct.Description,
                    Price = updatedProduct.Price,
                    StockQuantity = updatedProduct.StockQuantity,
                    CreatedAt = updatedProduct.CreatedAt,
                    UpdatedAt = updatedProduct.UpdatedAt
                };

            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
        }
    }
}
