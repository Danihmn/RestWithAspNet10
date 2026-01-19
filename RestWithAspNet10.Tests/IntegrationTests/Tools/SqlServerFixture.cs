using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Data.Context;
using Testcontainers.MsSql;

namespace RestWithAspNet10.Tests.IntegrationTests.Tools
{
    public class SqlServerFixture : IAsyncLifetime
    {
        public MsSqlContainer Container { get; }

        public string ConnectionString => Container.GetConnectionString();

        public SqlServerFixture()
        {
            Container = new MsSqlBuilder().WithPassword("Admin1234").Build();
        }

        public async Task InitializeAsync()
        {
            await Container.StartAsync(); // Creates the database
            await Task.Delay(TimeSpan.FromSeconds(3)); // Ensures that SQL Server is ready
            await ApplyMigrationsAsync(); // Run the migrations
        }

        private async Task ApplyMigrationsAsync()
        {
            DbContextOptionsBuilder<MsSqlContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(ConnectionString);

            using MsSqlContext context = new(optionsBuilder.Options);

            await context.Database.MigrateAsync();
        }

        public async Task DisposeAsync()
        {
            await Container.DisposeAsync();
        }
    }
}