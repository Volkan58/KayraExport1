using KayraWebAPI.Context;
using KayraWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KayraWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BaseDbContext _context;

        public ProductRepository(BaseDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid id, bool permanent = false)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            if (permanent)
            {
                _context.Products.Remove(product);
            }
            else
            {
                product.DeletedAt = DateTime.UtcNow;
                _context.Entry(product).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null && p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
