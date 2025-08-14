using KayraWebAPI.Dtos;

namespace KayraWebAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
        Task<GetProductDto?> GetProductByIdAsync(Guid id);
        Task<CreateProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<UpdateProductDto?> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(Guid id,bool permanent);
    }
}
