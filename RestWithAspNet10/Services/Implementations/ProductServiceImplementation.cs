using RestWithAspNet10.Data.Converters.Implementations;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class ProductServiceImplementation : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductConverter _converter;

        public ProductServiceImplementation (IProductRepository repository)
        {
            _repository = repository;
            _converter = new ProductConverter();
        }

        public List<ProductDTO> FindAll ()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public ProductDTO FindById (long id)
        {
            return _converter.Parse(_repository.FindById(id));

        }

        public ProductDTO Create (ProductDTO product)
        {
            ProductModel entity = _converter.Parse(product);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public ProductDTO Update (ProductDTO product)
        {
            ProductModel entity = _converter.Parse(product);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }

        public void Delete (long id)
        {
            _repository.Delete(id);
        }

        public ProductDTO Disable (long id)
        {
            return _converter.Parse(_repository.Disable(id));
        }
    }
}
