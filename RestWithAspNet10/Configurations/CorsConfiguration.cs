namespace RestWithAspNet10.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            // Gets de origins defined at the appsettings
            var origins = configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", policy => policy
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowCredentials());
            });
        }

        public static IApplicationBuilder UseCorsConfiguration (this IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
            return app;
        }
    }
}
