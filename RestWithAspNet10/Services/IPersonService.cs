using RestWithAspNet10.Data.DTO.V1;

namespace RestWithAspNet10.Services
{
    public interface IPersonService
    {
        public List<PersonDTO> FindAll ();
        PersonDTO FindById (long id);
        PersonDTO Create (PersonDTO person);
        PersonDTO Update (PersonDTO person);
        void Delete (long id);
    }
}
