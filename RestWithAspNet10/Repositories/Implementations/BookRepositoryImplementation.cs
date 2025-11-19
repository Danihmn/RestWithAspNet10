using RestWithAspNet10.Models;
using RestWithAspNet10.Models.Context;

namespace RestWithAspNet10.Repositories.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MSSQLContext _context;

        public BookRepositoryImplementation (MSSQLContext context)
        {
            _context = context;
        }

        public List<BookModel> FindAll ()
        {
            return _context.Books.ToList();
        }

        public BookModel FindById (long id)
        {
            return _context.Books.Find(id);
        }

        public BookModel Create (BookModel book)
        {
            _context.Add(book);
            _context.SaveChanges();

            return book;
        }

        public BookModel Update (BookModel book)
        {
            var existingBook = _context.Books.Find(book.Id);

            if (existingBook == null) return null;

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return book;
        }

        public void Delete (long id)
        {
            var existingBook = _context.Books.Find(id);

            if (existingBook == null) return;

            _context.Remove(existingBook);
            _context.SaveChanges();
        }
    }
}
