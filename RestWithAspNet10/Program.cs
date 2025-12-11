using RestWithAspNet10.Configurations;
using RestWithAspNet10.Repositories;
using RestWithAspNet10.Repositories.Implementations;
using RestWithAspNet10.Services;
using RestWithAspNet10.Services.Implementations;

namespace RestWithAspNet10
{
    public class Program
    {
        public static void Main (string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registers the mappings for Mapster
            MapsterConfiguration.RegisterMappings();

            // Adds the Serilog´s logging configuration
            builder.AddSerilogLogging();

            // Adds the Controllers, then the Content Negotiation configuration
            builder.Services.AddControllers().AddContentNegotiation();

            builder.Services.AddEndpointsApiExplorer();

            // Adds the OpenAPI/Swagger configuration
            builder.Services.AddOpenAPIConfiguration();
            builder.Services.AddSwaggerConfiguration();

            // Adds the Database configuration
            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            // Dependency Injection configuration
            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V1.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V1.PersonDTO>>();
            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V2.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V2.PersonDTO>>();
            builder.Services.AddScoped<IBookService, BookServiceImplementation>();
            builder.Services.AddScoped<IProductService, ProductServiceImplementation>();

            // Generic Repository injection
            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImplementation<>));

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Enables the OpenAPI/Swagger middlewares
            app.UseSwaggerDocumentation();

            app.Run();
        }
    }
}
