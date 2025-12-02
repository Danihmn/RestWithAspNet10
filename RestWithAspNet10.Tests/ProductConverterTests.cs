using FluentAssertions;
using RestWithAspNet10.Data.Converters.Implementations;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Tests
{
    public class ProductConverterTests
    {
        private readonly ProductConverter _converter;

        public ProductConverterTests ()
        {
            _converter = new ProductConverter();
        }

        [Fact]
        public void Parse_ShouldConvertProductDTOToProductModelWithManualConverters ()
        {
            // Arrange
            ProductDTO originProductDTO = new ProductDTO
            {
                Id = 1,
                Name = "Inspiron 15 3520",
                Description = "intel Core i5, 512 GB, 8 GB RAM",
                Brand = "Dell",
                QuantityStock = 5,
                CostPrice = 1000
            };

            ProductModel expectedProductModel = new ProductModel
            {
                Id = 1,
                Name = "Inspiron 15 3520",
                Description = "intel Core i5, 512 GB, 8 GB RAM",
                Brand = "Dell",
                QuantityStock = 5,
                CostPrice = 1000,
                SalePrice = 2000
            };

            // Act
            ProductModel resultProduct = _converter.Parse(originProductDTO);

            // Assert
            resultProduct.Should().BeEquivalentTo(expectedProductModel, options => options.Excluding(product => product.SalePrice));
            resultProduct.SalePrice.Should().Be(expectedProductModel.CostPrice * 2);
        }

        [Fact]
        public void Parse_ShouldReturnAtNullValuesCaseAtConvertProductDTOToProductModelWithManualConverters ()
        {
            // Arrange
            ProductDTO originProductDTO = null;

            ProductModel expectedProductModel = new ProductModel
            {
                Id = 1,
                Name = "Inspiron 15 3520",
                Description = "intel Core i5, 512 GB, 8 GB RAM",
                Brand = "Dell",
                QuantityStock = 5,
                CostPrice = 1000,
                SalePrice = 2000
            };

            // Act
            ProductModel resultProduct = _converter.Parse(originProductDTO);

            // Assert
            resultProduct.Should().BeNull();
        }
    }
}
