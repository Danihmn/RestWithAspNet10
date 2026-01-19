using RestWithAspNet10.Data.Context;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Repositories.Implementations
{
    public class ProductRepositoryImplementation(MsSqlContext context) :
        RepositoryImplementation<ProductModel>(context), IProductRepository
    {
        public List<ProductModel> FindBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand)) return null;

            return _context.Products
                .Where(product => product.Brand.ToLower().Contains(brand.ToLower())).ToList();
        }

        public ProductModel Disable(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return null;
            product.Enabled = false;
            _context.SaveChanges();
            return product;
        }
    }
}