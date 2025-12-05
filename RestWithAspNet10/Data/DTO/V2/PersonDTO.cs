using RestWithAspNet10.JsonConverters;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V2
{
    public record PersonDTO
    {
        [JsonPropertyName("identifier")]
        public long Id { get; init; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; init; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; init; }

        public string? Address { get; init; }

        [JsonConverter(typeof(GenderConverter))]
        public string? Gender { get; init; }

        [JsonPropertyName("birth_day")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? BirthDay { get; init; }

    }
}
