using Microsoft.OpenApi;

namespace RestWithAspNet10.Configurations
{
    public static class SwaggerConfiguration
    {
        private static readonly string AppName = "ASP.NET 2026 REST API´s";
        private static readonly string AppDescription = $"API ASP.NET developed in course '{AppName}'";

        public static IServiceCollection AddSwaggerConfiguration (this IServiceCollection services)
        {
            // Registers the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                // Defines the Swagger document information
                options.SwaggerDoc("v1", new OpenApiInfo
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

                // Shows the endpoint´s full context
                options.CustomSchemaIds(type => type.FullName);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation (this IApplicationBuilder app)
        {
            // Enables the middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });

            return app;
        }
    }
}
