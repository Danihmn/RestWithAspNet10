using Mapster;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Configurations
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings()
        {
            // V2
            TypeAdapterConfig<PersonModel, RestWithAspNet10.Data.DTO.V2.PersonDTO>
                .NewConfig().Map(dest => dest.BirthDay, src => DateTime.Now);
        }
    }
}