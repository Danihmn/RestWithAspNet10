using RestWithAspNet10.Data.Converter.Contract;
using RestWithAspNet10.Data.DTO;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Data.Converter.Implementation
{
    public class PersonConverterImplementation :
        IConverterContract<PersonDTO, PersonModel>,
        IConverterContract<PersonModel, PersonDTO>
    {
        public PersonModel Parse (PersonDTO origin)
        {
            if (origin == null) return null;

            return new PersonModel
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
            };
        }

        public PersonDTO Parse (PersonModel origin)
        {
            if (origin == null) return null;

            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
            };
        }

        public List<PersonModel> ParseList (List<PersonDTO> originList)
        {
            if (originList == null) return null;

            return originList.Select(item => Parse(item)).ToList();
        }

        public List<PersonDTO> ParseList (List<PersonModel> originList)
        {
            if (originList == null) return null;

            return originList.Select(item => Parse(item)).ToList();
        }
    }
}
