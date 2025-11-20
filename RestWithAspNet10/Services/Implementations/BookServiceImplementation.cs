using RestWithAspNet10.Data.Converter.Implementation;
using RestWithAspNet10.Data.DTO;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private readonly IRepository<BookModel> _repository;
        private readonly BookConverterImplementation _converter;

        public BookServiceImplementation (IRepository<BookModel> repository)
        {
            _repository = repository;
            _converter = new BookConverterImplementation();
        }

        public List<BookDTO> FindAll ()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookDTO FindById (long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookDTO Create (BookDTO book)
        {
            BookModel entity = _converter.Parse(book);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public BookDTO Update (BookDTO book)
        {
            BookModel entity = _converter.Parse(book);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }

        public void Delete (long id)
        {
            _repository.Delete(id);
        }
    }
}