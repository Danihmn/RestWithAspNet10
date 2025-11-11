using RestWithAspNet10.Models;

namespace RestWithAspNet10.Services
{
    public interface IPersonService
    {
        PersonModel Create (PersonModel person);
        PersonModel FindById (long id);
        PersonModel Update (PersonModel person);
        void Delete (long id);
    }
}
