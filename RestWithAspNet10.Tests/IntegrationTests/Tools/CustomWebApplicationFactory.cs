using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace RestWithAspNet10.Tests.IntegrationTests.Tools
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly string _connectionString;

        public CustomWebApplicationFactory (string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureWebHost (IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var allowedDomainDictionary = new Dictionary<string, string>
                {
                    ["Cors:Origins"] = "http://localhost:3000",
                };

                var connectionStringDictionary = new Dictionary<string, string>
                {
                    {
                        "ConnectionStrings:DefaultConnection", _connectionString
                    }
                };

                config.AddInMemoryCollection(allowedDomainDictionary!);
                config.AddInMemoryCollection(connectionStringDictionary!);
            });
        }
    }
}
