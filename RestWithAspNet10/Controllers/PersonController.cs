using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Models;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController (IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll () => Ok(_personService.FindAll());

        [HttpGet("{id}")]
        public IActionResult GetById (long id) =>
            _personService.FindById(id) == null ? NotFound() : Ok(_personService.FindById(id));

        [HttpPost]
        public IActionResult Create ([FromBody] PersonModel person) =>
            Ok(_personService.Create(person));

        [HttpPut]
        public IActionResult Update ([FromBody] PersonModel person, long id) =>
            _personService.FindById(id) == null ? NotFound() : Ok(_personService.Update(person));

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            if (_personService.FindById(id) == null) return NotFound();

            _personService.Delete(id);
            return NoContent();
        }
    }
}
