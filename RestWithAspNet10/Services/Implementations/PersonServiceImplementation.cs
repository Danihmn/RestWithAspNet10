using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        IPersonRepository _repository;

        public PersonServiceImplementation (IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<PersonModel> FindAll () => _repository.FindAll();

        public PersonModel FindById (long id) => _repository.FindById(id);

        public PersonModel Create (PersonModel person) => _repository.Create(person);

        public PersonModel Update (PersonModel person) => _repository.Update(person);

        public void Delete (long id) => _repository.Delete(id);
    }
}
