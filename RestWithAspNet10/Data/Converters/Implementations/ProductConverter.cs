using RestWithAspNet10.Data.Converters.Contract;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Data.Converters.Implementations
{
    public class ProductConverter : IConverterContract<ProductModel, ProductDTO>, IConverterContract<ProductDTO, ProductModel>
    {
        public ProductDTO Parse (ProductModel origin)
        {
            if (origin == null) return null;
            return new ProductDTO
            {
                Id = origin.Id,
                Name = origin.Name,
                Description = origin.Description,
                QuantityStock = origin.QuantityStock,
                CostPrice = origin.CostPrice,
            };
        }

        public ProductModel Parse (ProductDTO origin)
        {
            if (origin == null) return null;
            return new ProductModel
            {
                Id = origin.Id,
                Name = origin.Name,
                Description = origin.Description,
                QuantityStock = origin.QuantityStock,
                CostPrice = origin.CostPrice,
                SalePrice = origin.CostPrice * 2
            };
        }

        public List<ProductDTO> ParseList (List<ProductModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();

        }

        public List<ProductModel> ParseList (List<ProductDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
