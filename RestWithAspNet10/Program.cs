using RestWithAspNet10.Configurations;
using RestWithAspNet10.Data.Converter.Implementation;
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

            builder.AddSerilogLogging();

            builder.Services.AddControllers();

            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
            builder.Services.AddScoped<IBookService, BookServiceImplementation>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImplementation<>));

            builder.Services.AddScoped<PersonConverterImplementation>();
            builder.Services.AddScoped<BookConverterImplementation>();

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
