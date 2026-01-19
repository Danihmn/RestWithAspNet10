namespace RestWithAspNet10.Services
{
    public interface IPersonService<T>
    {
        public List<T> FindAll();
        T FindById(long id);
        T Create(T person);
        T Update(T person);
        void Delete(long id);
    }
}