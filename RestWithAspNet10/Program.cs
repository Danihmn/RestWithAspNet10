using RestWithAspNet10.Configurations;
using RestWithAspNet10.Hypermedia.Filters;
using RestWithAspNet10.Repositories;
using RestWithAspNet10.Repositories.Implementations;
using RestWithAspNet10.Services;
using RestWithAspNet10.Services.Implementations;

namespace RestWithAspNet10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registers the mappings for Mapster
            MapsterConfiguration.RegisterMappings();

            // Adds the Serilog logging configuration
            builder.AddSerilogLogging();

            // Adds the Controllers, then the Content Negotiation configuration
            builder.Services.AddControllers(options => options.Filters.Add<HypermediaFilter>()).AddContentNegotiation();

            builder.Services.AddEndpointsApiExplorer();

            // Adds the OpenAPI, Swagger and Route customization configuration
            builder.Services.AddOpenAPIConfiguration();
            builder.Services.AddSwaggerConfiguration();
            builder.Services.AddRouteConfiguration();

            // Adds the CORS Policies
            builder.Services.AddCorsConfiguration(builder.Configuration);

            // Adds the HATEOAS configuration
            builder.Services.AddHateoasConfiguration();

            // Adds the Database configuration
            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            // Dependency Injection configuration
            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V1.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V1.PersonDTO>>();
            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V2.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V2.PersonDTO>>();
            builder.Services.AddScoped<IBookService, BookServiceImplementation>();
            builder.Services.AddScoped<IProductService, ProductServiceImplementation>();

            // Custom Repository injection
            builder.Services.AddScoped<IProductRepository, ProductRepositoryImplementation>();

            // Generic Repository injection
            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImplementation<>));

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();

            // Enables the CORS Configurations
            app.UseCorsConfiguration(builder.Configuration);

            app.MapControllers();

            app.UseHateoasRoutes();

            // Enables the API documentation
            app.UseSwaggerDocumentation();
            app.UseScalarDocumentation();

            app.Run();
        }
    }
}