using Mapster;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private readonly IRepository<BookModel> _repository;

        public BookServiceImplementation(IRepository<BookModel> repository)
        {
            _repository = repository;
        }

        public List<BookDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BookDTO>>();
        }

        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Create(BookDTO book)
        {
            BookModel entity = book.Adapt<BookModel>();
            entity = _repository.Create(entity);

            return entity.Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO book)
        {
            BookModel entity = book.Adapt<BookModel>();
            entity = _repository.Update(entity);

            return entity.Adapt<BookDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}