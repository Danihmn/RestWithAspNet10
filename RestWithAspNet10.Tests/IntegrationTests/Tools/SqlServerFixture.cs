using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Data.Context;
using Testcontainers.MsSql;

namespace RestWithAspNet10.Tests.IntegrationTests.Tools
{
    public class SqlServerFixture : IAsyncLifetime
    {
        public MsSqlContainer Container { get; }

        public string ConnectionString => Container.GetConnectionString();

        SqlServerFixture ()
        {
            Container = new MsSqlBuilder().WithPassword("Admin1234").Build();
        }

        public async Task InitializeAsync ()
        {
            await Container.StartAsync();
            await ApplyMigrationsAsync();
        }

        private async Task ApplyMigrationsAsync ()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MsSqlContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            using var context = new MsSqlContext(optionsBuilder.Options);

            await context.Database.MigrateAsync();
        }

        public async Task DisposeAsync ()
        {
            await Container.DisposeAsync();
        }
    }
}
