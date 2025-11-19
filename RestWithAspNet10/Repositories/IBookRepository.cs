using RestWithAspNet10.Models;

namespace RestWithAspNet10.Repositories
{
    public interface IBookRepository
    {
        BookModel Create (BookModel book);

        BookModel FindById (long id);

        List<BookModel> FindAll ();

        BookModel Update (BookModel book);

        void Delete (long id);
    }
}
