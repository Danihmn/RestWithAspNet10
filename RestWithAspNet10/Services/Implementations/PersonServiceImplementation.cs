using Mapster;
using RestWithAspNet10.Models;
using RestWithAspNet10.Repositories;

namespace RestWithAspNet10.Services.Implementations
{
    public class PersonServiceImplementation<T> : IPersonService<T>
    {
        private readonly IRepository<PersonModel> _repository;

        public PersonServiceImplementation (IRepository<PersonModel> repository)
        {
            _repository = repository;
        }

        public List<T> FindAll ()
        {
            return _repository.FindAll().Adapt<List<T>>();
        }

        public T FindById (long id)
        {
            return _repository.FindById(id).Adapt<T>();
        }

        public T Create (T person)
        {
            PersonModel entity = person.Adapt<PersonModel>();
            entity = _repository.Create(entity);

            return entity.Adapt<T>();
        }

        public T Update (T person)
        {
            PersonModel entity = person.Adapt<PersonModel>();
            entity = _repository.Update(entity);

            return entity.Adapt<T>();
        }

        public void Delete (long id)
        {
            _repository.Delete(id);
        }
    }
}
