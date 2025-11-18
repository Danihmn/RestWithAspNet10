using RestWithAspNet10.Models;

namespace RestWithAspNet10.Repositories
{
    public interface IPersonRepository
    {
        PersonModel Create (PersonModel person);
        PersonModel FindById (long id);
        public List<PersonModel> FindAll ();
        PersonModel Update (PersonModel person);
        void Delete (long id);
    }
}
