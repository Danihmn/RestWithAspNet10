using RestWithAspNet10.Models;
using RestWithAspNet10.Models.Context;

namespace RestWithAspNet10.Repositories.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        MSSQLContext _context;

        public PersonRepositoryImplementation (MSSQLContext context)
        {
            _context = context;
        }

        public List<PersonModel> FindAll () => _context.Persons.ToList();

        public PersonModel FindById (long id) => _context.Persons.Find(id);

        public PersonModel Create (PersonModel person)
        {
            var createdPerson = _context.Persons.Add(person).Entity;

            _context.SaveChanges();

            return createdPerson;
        }

        public PersonModel Update (PersonModel person)
        {
            var existingPerson = _context.Persons.Find(person.Id);

            if (existingPerson == null) throw new Exception("Pessoa não encontrada");

            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();

            return person;
        }

        public void Delete (long id)
        {
            var existingPerson = _context.Persons.Find(id);

            if (existingPerson == null) throw new Exception("Pessoa não encontrada");

            _context.Persons.Remove(existingPerson);
            _context.SaveChanges();
        }
    }
}
