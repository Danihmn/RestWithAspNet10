using RestWithAspNet10.Hypermedia.Enricher;
using RestWithAspNet10.Hypermedia.Filters;

namespace RestWithAspNet10.Configurations
{
    public static class HateoasConfiguration
    {
        public static IServiceCollection AddHateoasConfiguration (this IServiceCollection services)
        {
            var filterOptions = new HypermediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);
            services.AddScoped<HypermediaFilter>();
            return services;
        }

        public static void UseHateoasRoutes (this IEndpointRouteBuilder app)
        {
            app.MapControllerRoute("Default", "{controller=values}/api/v1/{id?}");
        }
    }
}
