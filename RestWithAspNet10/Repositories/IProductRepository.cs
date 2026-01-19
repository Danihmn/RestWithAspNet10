using RestWithAspNet10.Models;

namespace RestWithAspNet10.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        ProductModel Disable(long id);
        List<ProductModel> FindBrand(string brand);
    }
}