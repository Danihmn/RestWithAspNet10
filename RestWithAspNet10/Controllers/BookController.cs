using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController (IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get ()
        {
            _logger.LogInformation("Buscando todos os livros");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get (long id)
        {
            _logger.LogInformation("Buscando livro pelo ID {id}", id);

            BookDTO book = _bookService.FindById(id);

            if (book == null)
            {
                _logger.LogWarning("Livro com ID {id} não encontrado", id);
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] BookDTO book)
        {
            _logger.LogInformation("Criando novo livro: {firstName}", book.Title);

            BookDTO createdBook = _bookService.Create(book);

            if (createdBook != null)
                return Ok(createdBook);

            _logger.LogError("Falha ao tentar criar o livro {firstName}", book.Title);

            return NotFound();
        }

        [HttpPut]
        public IActionResult Put ([FromBody] BookDTO book)
        {
            _logger.LogInformation("Alterando livro com ID {id}", book.Id);

            BookDTO createdBook = _bookService.Update(book);

            if (createdBook == null)
            {
                _logger.LogError("Falha ao tentar alterar livro com ID {id}", book.Id);
                return NotFound();
            }

            _logger.LogDebug("Livro alterado com sucesso: {firstName}", createdBook.Title);

            return Ok(createdBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _logger.LogInformation("Deletando livro pelo ID {id}", id);
            _bookService.Delete(id);
            _logger.LogDebug("Livro com ID {id} deletado com sucesso", id);

            return NoContent();
        }
    }
}
