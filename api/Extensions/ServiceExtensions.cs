using api.Contracts;
using api.Data;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
            );
        }
    }
}
