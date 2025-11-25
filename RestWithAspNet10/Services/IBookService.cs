using RestWithAspNet10.Data.DTO;

namespace RestWithAspNet10.Services
{
    public interface IBookService
    {
        List<BookDTO> FindAll ();
        BookDTO FindById (long id);
        BookDTO Create (BookDTO book);
        BookDTO Update (BookDTO book);
        void Delete (long id);
    }

}
