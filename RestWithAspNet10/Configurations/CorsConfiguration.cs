namespace RestWithAspNet10.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("LocalPolicy", policy => policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowCredentials());
            });
        }

        public static IApplicationBuilder UseCorsConfiguration (this IApplicationBuilder app)
        {
            app.UseCors();
            return app;
        }
    }
}
