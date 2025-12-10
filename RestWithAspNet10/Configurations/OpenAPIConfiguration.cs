using Microsoft.OpenApi;

namespace RestWithAspNet10.Configurations
{
    public static class OpenAPIConfiguration
    {
        private static readonly string AppName = "ASP.NET 2026 REST API´s";
        private static readonly string AppDescription = $"API ASP.NET developed in course '{AppName}'";

        public static IServiceCollection AddOpenAPIConfiguration (this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Daniel Eduardo Pratta Bezerra",
                    Email = "daniel.bezerra.mult@outlook.com"
                }
            });

            return services;
        }
    }
}
