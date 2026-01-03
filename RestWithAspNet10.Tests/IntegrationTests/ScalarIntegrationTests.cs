using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithAspNet10.Tests.IntegrationTests.Tools;

namespace RestWithAspNet10.Tests.IntegrationTests
{
    public class ScalarIntegrationTests : IClassFixture<SqlServerFixture>
    {
        public readonly HttpClient _httpClient;

        public ScalarIntegrationTests (SqlServerFixture sqlServerFixture)
        {
            var factory = new CustomWebApplicationFactory<Program>(sqlServerFixture.ConnectionString);

            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost")
                }
            );
        }

        [Fact]
        public async Task ScalarUI_ShouldReturnScalarUI ()
        {
            // Arrange & Act
            var response = await _httpClient.GetAsync("/scalar/");

            // Assert
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            content.Should().Contain("<title>ASP.NET 2026 REST API´s</title>");
        }
    }
}
