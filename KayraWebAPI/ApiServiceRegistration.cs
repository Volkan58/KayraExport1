using KayraWebAPI.Repository;
using KayraWebAPI.Services;

namespace KayraWebAPI
{
    public static class ApiServiceRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            return services;
        }
        }
}
