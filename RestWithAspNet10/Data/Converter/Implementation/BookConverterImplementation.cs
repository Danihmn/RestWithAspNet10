using RestWithAspNet10.Data.Converter.Contract;
using RestWithAspNet10.Data.DTO;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Data.Converter.Implementation
{
    public class BookConverterImplementation :
        IConverterContract<BookDTO, BookModel>,
        IConverterContract<BookModel, BookDTO>
    {
        public BookModel Parse (BookDTO origin)
        {
            if (origin == null) return null;

            return new BookModel
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
            };
        }

        public BookDTO Parse (BookModel origin)
        {
            if (origin == null) return null;

            return new BookDTO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
            };
        }

        public List<BookModel> ParseList (List<BookDTO> originList)
        {
            if (originList == null) return null;

            return originList.Select(item => Parse(item)).ToList();
        }

        public List<BookDTO> ParseList (List<BookModel> originList)
        {
            if (originList == null) return null;

            return originList.Select(item => Parse(item)).ToList();
        }
    }
}
