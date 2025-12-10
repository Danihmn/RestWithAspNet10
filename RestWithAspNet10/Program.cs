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

            MapsterConfiguration.RegisterMappings();

            builder.AddSerilogLogging();

            builder.Services.AddControllers().AddContentNegotiation();

            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V1.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V1.PersonDTO>>();

            builder.Services.AddScoped<IPersonService<RestWithAspNet10.Data.DTO.V2.PersonDTO>,
                PersonServiceImplementation<RestWithAspNet10.Data.DTO.V2.PersonDTO>>();

            builder.Services.AddScoped<IBookService, BookServiceImplementation>();

            builder.Services.AddScoped<IProductService, ProductServiceImplementation>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImplementation<>));

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
