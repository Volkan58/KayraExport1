using KayraWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KayraWebAPI.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
