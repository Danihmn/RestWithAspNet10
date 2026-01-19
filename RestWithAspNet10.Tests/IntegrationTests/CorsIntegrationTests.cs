using Microsoft.AspNetCore.Mvc.Testing;
using RestWithAspNet10.Tests.IntegrationTests.Tools;
using System.Net;

namespace RestWithAspNet10.Tests.IntegrationTests
{
    public class CorsIntegrationTests : IClassFixture<SqlServerFixture>
    {
        public readonly HttpClient _httpClient;

        public CorsIntegrationTests(SqlServerFixture sqlServerFixture)
        {
            var factory = new CustomWebApplicationFactory<Program>(sqlServerFixture.ConnectionString);

            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost:3000")
                }
            );
        }

        [Fact]
        public async Task Cors_Should_Allow_Configured_Origins()
        {
            // Arrange
            var origin = "http://localhost:3000";
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/person");

            request.Headers.Add("Origin", origin);
            request.Headers.Add("Accept", "*/*");

            // Act
            var response = _httpClient.SendAsync(request).Result;

            // Assert
            Assert.True(response.Headers.Contains("Access-Control-Allow-Origin"));
            var allowedOrigin = response.Headers.GetValues("Access-Control-Allow-Origin").First();
            Assert.Equal(origin, allowedOrigin);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Cors_Should_Reject_Not_Configured_Origins()
        {
            // Arrange
            var origin = "http://evil-domain.com";
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/person");

            request.Headers.Add("Origin", origin);
            request.Headers.Add("Accept", "*/*");

            // Act
            var response = _httpClient.SendAsync(request).Result;

            // Assert
            Assert.False(response.Headers.Contains("Access-Control-Allow-Origin"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("http://localhost:3000", true)]
        [InlineData("http://evil.com", false)]
        [InlineData("https://hacker.com", false)]
        public async Task Cors_Should_Validate_Multiple_Origins(string origin, bool shouldAllow)
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/person");
            request.Headers.Add("Origin", origin);

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            var hasAllowOriginHeader = response.Headers.Contains("Access-Control-Allow-Origin");

            if (shouldAllow)
            {
                Assert.True(hasAllowOriginHeader);
                var allowedOrigin = response.Headers.GetValues("Access-Control-Allow-Origin").First();
                Assert.Equal(origin, allowedOrigin);
            }
            else
            {
                Assert.False(hasAllowOriginHeader);
            }
        }
    }
}