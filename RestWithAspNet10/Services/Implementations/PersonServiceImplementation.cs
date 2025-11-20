using RestWithAspNet10.Data.Converter.Implementation;
using RestWithAspNet10.Data.DTO;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IRepository<PersonModel> _repository;
        private readonly PersonConverterImplementation _converter;

        public PersonServiceImplementation (IRepository<PersonModel> repository, PersonConverterImplementation converter)
        {
            _repository = repository;
            _converter = new PersonConverterImplementation();
        }

        public List<PersonDTO> FindAll ()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById (long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create (PersonDTO person)
        {
            PersonModel entity = _converter.Parse(person);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public PersonDTO Update (PersonDTO person)
        {
            PersonModel entity = _converter.Parse(person);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }

        public void Delete (long id)
        {
            _repository.Delete(id);
        }
    }
}
