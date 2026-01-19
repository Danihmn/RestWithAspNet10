using RestWithAspNet10.Models.Base;

namespace RestWithAspNet10.Repositories
{
    public interface IRepository<T> where T : ModelBase
    {
        T Create(T item);

        T FindById(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        bool Exists(long id);
    }
}