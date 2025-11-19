namespace RestWithAspNet10.Configurations
{
    public static class EvolveConfiguration
    {
        public static IServiceCollection AddEvolveConfiguration (
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment
            )
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLServerConnection:DefaultConnection"];

                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentNullException("Connection string 'MSSQLServer não encontrada");
            }

            return services;
        }
    }
}
