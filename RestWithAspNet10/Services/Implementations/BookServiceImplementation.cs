using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private IBookRepository _repository;

        public BookServiceImplementation (IBookRepository repository)
        {
            _repository = repository;
        }

        public List<BookModel> FindAll ()
        {
            return _repository.FindAll();
        }

        public BookModel FindById (long id)
        {
            return _repository.FindById(id);
        }

        public BookModel Create (BookModel book)
        {
            return _repository.Create(book);
        }

        public BookModel Update (BookModel book)
        {
            return _repository.Update(book);
        }
        public void Delete (long id)
        {
            _repository.Delete(id);
        }
    }

}
