using KayraWebAPI.Context;
using KayraWebAPI.Repository;
using KayraWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KayraWebAPI
{
    public static class ApiServiceRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(
                                                            configuration.GetConnectionString("kayraProjectConnectionString")),
                                                            ServiceLifetime.Scoped);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            return services;
        }
        }
}
