using Scalar.AspNetCore;

namespace RestWithAspNet10.Configurations
{
    public static class ScalarConfiguration
    {
        private static readonly string AppName = "ASP.NET 2026 REST API´s";

        public static WebApplication UseScalarDocumentation(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar", options =>
            {
                options
                    .WithTitle(AppName)
                    .WithOpenApiRoutePattern("/swagger/v1/swagger.json");
            });

            return app;
        }
    }
}