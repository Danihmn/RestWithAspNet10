using RestWithAspNet10.Models;

namespace RestWithAspNet10.Services
{
    public interface IBookService
    {
        BookModel Create (BookModel book);

        BookModel FindById (long id);

        List<BookModel> FindAll ();

        BookModel Update (BookModel book);

        void Delete (long id);
    }

}
