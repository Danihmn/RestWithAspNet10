using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Models.Context;

namespace RestWithAspNet10.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerConnection:DefaultConnection"];

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string 'MSSQLServer não encontrada");

            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
