using RestWithAspNet10.JsonConverters;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V2
{
    public class PersonDTO
    {
        [JsonPropertyName("identifier")]
        public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        public string? Address { get; set; }

        [JsonConverter(typeof(GenderConverter))]
        public string? Gender { get; set; }

        [JsonPropertyName("birth_day")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? BirthDay { get; set; }
    }
}
