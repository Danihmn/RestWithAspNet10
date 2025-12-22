using FluentAssertions;
using RestWithAspNet10.Data.Converters.Implementations;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Tests.UnitTests
{
    public class ProductConverterTests
    {
        private readonly ProductConverter _converter;

        public ProductConverterTests ()
        {
            _converter = new ProductConverter();
        }

        #region Convertions with not null values
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
        public void Parse_ShouldConvertProductModelToProductDTOWithManualConverters ()
        {
            // Arrange
            ProductModel originProductModel = new ProductModel
            {
                Id = 1,
                Name = "Inspiron 15 3520",
                Description = "intel Core i5, 512 GB, 8 GB RAM",
                Brand = "Dell",
                QuantityStock = 5,
                CostPrice = 1000,
                SalePrice = 2000
            };

            ProductDTO expectedProductDTO = new ProductDTO
            {
                Id = 1,
                Name = "Inspiron 15 3520",
                Description = "intel Core i5, 512 GB, 8 GB RAM",
                Brand = "Dell",
                QuantityStock = 5,
                SalePrice = 2000
            };

            // Act
            ProductDTO resultProduct = _converter.Parse(originProductModel);

            // Assert
            resultProduct.Should().BeEquivalentTo(expectedProductDTO, options => options.Excluding(product => product.CostPrice));
            resultProduct.SalePrice.Should().Be(expectedProductDTO.SalePrice);
        }

        [Fact]
        public void Parse_ShouldConvertProductDTOListToProductModelListWithManualConverters ()
        {
            // Arrange
            List<ProductDTO> originProductDTOList = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Inspiron 15 3520",
                    Description = "intel Core i5, 512 GB, 8 GB RAM",
                    Brand = "Dell",
                    QuantityStock = 5,
                    CostPrice = 1000
                },
                new ProductDTO
                {
                    Id = 2,
                    Name = "Ideapad Flex 5i",
                    Description = "intel Core i7, 256 GB, 8 GB RAM",
                    Brand = "Lenovo",
                    QuantityStock = 5,
                    CostPrice = 1500
                }
            };

            // Act
            List<ProductModel> expectedProductModelList = _converter.ParseList(originProductDTOList);

            // Assert
            expectedProductModelList.Should().NotBeNull();
            expectedProductModelList.Should().HaveCount(originProductDTOList.Count);
            expectedProductModelList.Should().BeEquivalentTo(originProductDTOList, options => options.Excluding(product => product.SalePrice));
            expectedProductModelList.Should().SatisfyRespectively(
            originProductDTOList.Select<ProductDTO, Action<ProductModel>>(origin => expected =>
            {
                expected.SalePrice.Should().Be(origin.CostPrice * 2);
            }).ToArray());
        }

        [Fact]
        public void Parse_ShouldConvertProductModelListToProductDTOListWithManualConverters ()
        {
            // Arrange
            List<ProductModel> originProductModelList = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Inspiron 15 3520",
                    Description = "intel Core i5, 512 GB, 8 GB RAM",
                    Brand = "Dell",
                    QuantityStock = 5,
                    CostPrice = 1000,
                    SalePrice = 2000
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Ideapad Flex 5i",
                    Description = "intel Core i7, 256 GB, 8 GB RAM",
                    Brand = "Lenovo",
                    QuantityStock = 5,
                    CostPrice = 1500,
                    SalePrice = 3000
                }
            };

            // Act
            List<ProductDTO> expectedProductDTOList = _converter.ParseList(originProductModelList);

            // Assert
            expectedProductDTOList.Should().NotBeNull();
            expectedProductDTOList.Should().HaveCount(originProductModelList.Count);
            expectedProductDTOList.Should().BeEquivalentTo(originProductModelList, options => options.Excluding(product => product.CostPrice));
            expectedProductDTOList.Should().SatisfyRespectively(
            originProductModelList.Select<ProductModel, Action<ProductDTO>>(origin => expected =>
            {
                expected.SalePrice.Should().Be(origin.SalePrice);
            }).ToArray());
        }
        #endregion

        #region Convertions with null values
        [Fact]
        public void Parse_ShouldReturnAtNullValuesCaseAtConvertProductDTOToProductModelWithManualConverters ()
        {
            // Arrange
            ProductDTO originProductDTO = null;

            // Act
            ProductModel resultProduct = _converter.Parse(originProductDTO);

            // Assert
            resultProduct.Should().BeNull();
        }

        [Fact]
        public void Parse_ShouldReturnAtNullValuesCaseAtConvertProductModelToProductDTOWithManualConverters ()
        {
            // Arrange
            ProductModel originProductModel = null;

            // Act
            ProductDTO resultProduct = _converter.Parse(originProductModel);

            // Assert
            resultProduct.Should().BeNull();
        }

        [Fact]
        public void Parse_ShouldReturnAtNullValuesCaseAtConvertProductDTOListToProductModelListWithManualConverters ()
        {
            // Arrange
            List<ProductDTO> originProductDTOList = null;

            // Act
            List<ProductModel> resultProduct = _converter.ParseList(originProductDTOList);

            // Assert
            resultProduct.Should().BeNull();
        }

        [Fact]
        public void Parse_ShouldReturnAtNullValuesCaseAtConvertProductModelListToProductDTOListWithManualConverters ()
        {
            // Arrange
            List<ProductModel> originProductModelList = null;

            // Act
            List<ProductDTO> resultProduct = _converter.ParseList(originProductModelList);

            // Assert
            resultProduct.Should().BeNull();
        }
        #endregion
    }
}
