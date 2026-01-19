using Microsoft.AspNetCore.Mvc.Testing;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Tests.IntegrationTests.Tools;
using System.Net;
using System.Net.Http.Json;

namespace RestWithAspNet10.Tests.IntegrationTests.Product
{
    public class ProducControllerJsonIntegrationTests : IClassFixture<SqlServerFixture>
    {
        public readonly HttpClient _httpClient;

        public ProducControllerJsonIntegrationTests(SqlServerFixture sqlServerFixture)
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
        public async Task Get_Should_Return_Status_Code_200()
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

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"api/v1/product");
            getRequest.Headers.Add("Accept", "*/*");

            // Act
            var getResponse = await _httpClient.SendAsync(getRequest);

            // Assert
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var products = await getResponse.Content.ReadFromJsonAsync<List<ProductDTO>>();

            Assert.NotNull(products);
            Assert.NotEmpty(products);

            var createdProduct = products.FirstOrDefault(p => p.Name == newProduct.Name);

            Assert.Equal(newProduct.Name, createdProduct.Name);
            Assert.Equal(newProduct.Description, createdProduct.Description);
            Assert.Equal(newProduct.QuantityStock, createdProduct.QuantityStock);
            Assert.Equal(newProduct.Brand, createdProduct.Brand);
        }

        [Fact]
        public async Task Get_By_Id_Should_Return_Status_Code_200()
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

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"api/v1/product/{createdProduct.Id}");
            getRequest.Headers.Add("Accept", "*/*");

            // Act
            var getResponse = await _httpClient.SendAsync(getRequest);

            // Assert
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var updatedProduct = await getResponse.Content.ReadFromJsonAsync<ProductDTO>();

            Assert.NotNull(updatedProduct);
            Assert.Equal(newProduct.Name, updatedProduct.Name);
            Assert.Equal(newProduct.Description, updatedProduct.Description);
            Assert.Equal(newProduct.QuantityStock, updatedProduct.QuantityStock);
            Assert.Equal(newProduct.Brand, updatedProduct.Brand);
            Assert.Equal(newProduct.Enabled, updatedProduct.Enabled);
        }

        [Fact]
        public async Task Post_Should_Return_Status_Code_200()
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

            // Act
            var postResponse = await _httpClient.SendAsync(postRequest);

            // Assert
            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);

            var updatedProduct = await postResponse.Content.ReadFromJsonAsync<ProductDTO>();

            Assert.NotNull(updatedProduct);
            Assert.Equal(newProduct.Name, updatedProduct.Name);
            Assert.Equal(newProduct.Description, updatedProduct.Description);
            Assert.Equal(newProduct.QuantityStock, updatedProduct.QuantityStock);
            Assert.Equal(newProduct.Brand, updatedProduct.Brand);
            Assert.Equal(newProduct.Enabled, updatedProduct.Enabled);
        }

        [Fact]
        public async Task Put_Should_Return_Status_Code_200()
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

            var patchRequest = new HttpRequestMessage(HttpMethod.Put, $"api/v1/product/{createdProduct.Id}")
            {
                Content = JsonContent.Create(new ProductDTO
                {
                    Id = createdProduct.Id,
                    Name = "MacBook Air M4",
                    Description = "256 GB SSD 24 GB RAM",
                    Brand = "Apple",
                    QuantityStock = 4,
                    Enabled = true,
                })
            };
            patchRequest.Headers.Add("Accept", "*/*");

            // Act
            var patchResponse = await _httpClient.SendAsync(patchRequest);

            // Assert
            Assert.Equal(HttpStatusCode.OK, patchResponse.StatusCode);

            var updatedProduct = await patchResponse.Content.ReadFromJsonAsync<ProductDTO>();

            Assert.NotNull(updatedProduct);
            Assert.NotEqual(newProduct.Name, updatedProduct.Name);
            Assert.NotEqual(newProduct.Description, updatedProduct.Description);
            Assert.NotEqual(newProduct.QuantityStock, updatedProduct.QuantityStock);
            Assert.NotEqual(newProduct.Brand, updatedProduct.Brand);
            Assert.Equal(newProduct.Enabled, updatedProduct.Enabled);
        }

        [Fact]
        public async Task Patch_Should_Return_Status_Code_200()
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
            var patchResponse = await _httpClient.SendAsync(patchRequest);

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

        [Fact]
        public async Task Delete_Should_Return_Status_Code_204()
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

            var patchRequest = new HttpRequestMessage(HttpMethod.Delete, $"api/v1/product/{createdProduct.Id}");
            patchRequest.Headers.Add("Accept", "*/*");

            // Act
            var deleteResponse = await _httpClient.SendAsync(patchRequest);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}