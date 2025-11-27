using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Data.DTO.V2;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService<PersonDTO> _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController (IPersonService<PersonDTO> personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll ()
        {
            _logger.LogInformation("Buscando todas as pessoas");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById (long id)
        {
            _logger.LogInformation($"Buscando pessoa pelo Id {id}");

            PersonDTO person = _personService.FindById(id);

            if (person == null)
            {
                _logger.LogWarning($"Pessoa com ID {id} não encontrada");
                return NotFound();
            }

            return Ok(person);
        }
    }
}
