using RestWithAspNet10.Data.DTO.V1;

namespace RestWithAspNet10.Services
{
    public interface IProductService
    {
        public List<ProductDTO> FindAll();
        ProductDTO FindById(long id);
        public List<ProductDTO> FindByBrand(string brand);
        ProductDTO Create(ProductDTO product);
        ProductDTO Update(ProductDTO product);
        void Delete(long id);
        ProductDTO Disable(long id);
    }
}