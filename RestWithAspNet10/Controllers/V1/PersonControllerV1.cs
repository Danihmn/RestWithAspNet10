using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
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

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

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

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] PersonDTO person)
        {
            PersonDTO createdPerson = _personService.Create(person);

            _logger.LogInformation($"Criando nova pessoa: {person.FirstName}");

            if (createdPerson == null)
            {
                _logger.LogError("Erro ao tentar criar nova pessoa");
                return NotFound();
            }

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Update ([FromBody] PersonDTO person, long id)
        {
            PersonDTO updatedPerson = _personService.Update(person);

            _logger.LogInformation($"Alterando pessoa: {person.FirstName}");

            if (updatedPerson == null)
            {
                _logger.LogError($"Erro ao tentar alterar pessoa: {person.FirstName}, ID {person.Id}");
                return NotFound();
            }

            _logger.LogDebug($"Pessoa atualizada com sucesso: {updatedPerson.FirstName}");

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            if (_personService.FindById(id) == null) return NotFound();

            _logger.LogInformation($"Removendo pessoa pelo Id {id}");
            _personService.Delete(id);

            Response.Headers.Append("X-API_Deprecated", "True");
            Response.Headers.Append("X-API_Deprecation-Date", "2026-12-31");

            return NoContent();
        }
    }
}
