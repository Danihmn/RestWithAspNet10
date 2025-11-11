using RestWithAspNet10.Models;

namespace RestWithAspNet10.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public PersonModel Create (PersonModel person)
        {
            return person;
        }

        public PersonModel FindById (long id)
        {
            return MockPerson((int)id);
        }

        public List<PersonModel> FindAll ()
        {
            List<PersonModel> people = new();

            for (int i = 0; i >= 8; i++)
            {
                people.Add(MockPerson(i));
            }

            return people;
        }

        public PersonModel Update (PersonModel person)
        {
            return person;
        }

        public void Delete (long id)
        {
            // Simula lógica de deleção
        }
        private PersonModel MockPerson (int index)
        {
            PersonModel person = new()
            {
                Id = new Random().Next(1, 1000),
                FirstName = "Daniel Eduardo" + index,
                LastName = "Pratta Bezerra" + index,
                Address = "Av. Prof. Henrique" + index,
                Gender = "Male" + index
            };

            return person;
        }
    }
}
