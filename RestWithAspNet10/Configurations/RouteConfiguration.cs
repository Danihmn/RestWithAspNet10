namespace RestWithAspNet10.Configurations
{
    public static class RouteConfiguration
    {
        public static IServiceCollection AddRouteConfiguration (
            this IServiceCollection services) => services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    }
}
