namespace RestWithAspNet10.Configurations
{
    public static class CorsConfiguration
    {
        private static string[] GetAllowedOrigins (IConfiguration configuration) =>
            configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>();

        public static void AddCorsConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            // Gets de origins defined at the appsettings
            var origins = GetAllowedOrigins(configuration);
            var developmentOrigin = origins.ToList();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", policy => policy
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader());
            });
        }

        public static IApplicationBuilder UseCorsConfiguration (this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseCors("DefaultPolicy");

            return app;
        }
    }
}
