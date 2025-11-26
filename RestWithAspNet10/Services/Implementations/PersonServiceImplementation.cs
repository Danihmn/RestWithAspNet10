using Mapster;
using RestWithAspNet10.Data.DTO.V1;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IRepository<PersonModel> _repository;

        public PersonServiceImplementation (IRepository<PersonModel> repository)
        {
            _repository = repository;
        }

        public List<PersonDTO> FindAll ()
        {
            return _repository.FindAll().Adapt<List<PersonDTO>>();
        }

        public PersonDTO FindById (long id)
        {
            return _repository.FindById(id).Adapt<PersonDTO>();
        }

        public PersonDTO Create (PersonDTO person)
        {
            PersonModel entity = person.Adapt<PersonModel>();
            entity = _repository.Create(entity);

            return entity.Adapt<PersonDTO>();
        }

        public PersonDTO Update (PersonDTO person)
        {
            PersonModel entity = person.Adapt<PersonModel>();
            entity = _repository.Update(entity);

            return entity.Adapt<PersonDTO>();
        }

        public void Delete (long id)
        {
            _repository.Delete(id);
        }
    }
}
