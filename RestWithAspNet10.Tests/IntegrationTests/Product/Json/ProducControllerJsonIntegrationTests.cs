using Microsoft.AspNetCore.Mvc.Testing;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Tests.IntegrationTests.Tools;
using System.Net;
using System.Net.Http.Json;

namespace RestWithAspNet10.Tests.IntegrationTests
{
    public class ProducControllerJsonIntegrationTests : IClassFixture<SqlServerFixture>
    {
        public readonly HttpClient _httpClient;

        public ProducControllerJsonIntegrationTests (SqlServerFixture sqlServerFixture)
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
        public async Task Patch_Should_Return_Status_Code_200_And_Correctly_Updated_ProductDTO ()
        {
            // Arrange
            var newProduct = new ProductDTO
            {
                Name = "Test",
                Description = "Test",
                Brand = "Test",
                QuantityStock = 1,
                Enabled = true,
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/v1/product")
            {
                Content = JsonContent.Create(newProduct)
            };
            postRequest.Headers.Add("Accept", "*/*");

            var postResponse = await _httpClient.SendAsync(postRequest);
            postResponse.EnsureSuccessStatusCode();

            var createdProduct = await postResponse.Content.ReadFromJsonAsync<ProductDTO>();

            var patchRequest = new HttpRequestMessage(HttpMethod.Patch, $"api/v1/product/{createdProduct.Id}");
            patchRequest.Headers.Add("Accept", "*/*");

            // Act
            var patchResponse = _httpClient.SendAsync(patchRequest).Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, patchResponse.StatusCode);

            var updatedProduct = await patchResponse.Content.ReadFromJsonAsync<ProductDTO>();

            Assert.NotNull(updatedProduct);
            Assert.Equal(newProduct.Name, updatedProduct.Name);
            Assert.Equal(newProduct.Description, updatedProduct.Description);
            Assert.Equal(newProduct.QuantityStock, updatedProduct.QuantityStock);
            Assert.Equal(newProduct.Brand, updatedProduct.Brand);
            Assert.NotEqual(newProduct.Enabled, updatedProduct.Enabled);
        }
    }
}
