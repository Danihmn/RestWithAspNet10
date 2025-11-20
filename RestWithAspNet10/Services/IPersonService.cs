using RestWithAspNet10.Data.DTO;

namespace RestWithAspNet10.Services
{
    public interface IPersonService
    {
        PersonDTO Create (PersonDTO person);
        PersonDTO FindById (long id);
        public List<PersonDTO> FindAll ();
        PersonDTO Update (PersonDTO person);
        void Delete (long id);
    }
}
