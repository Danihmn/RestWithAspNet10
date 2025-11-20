using RestWithAspNet10.Data.DTO;

namespace RestWithAspNet10.Services
{
    public interface IBookService
    {
        BookDTO Create (BookDTO book);

        BookDTO FindById (long id);

        List<BookDTO> FindAll ();

        BookDTO Update (BookDTO book);

        void Delete (long id);
    }

}
