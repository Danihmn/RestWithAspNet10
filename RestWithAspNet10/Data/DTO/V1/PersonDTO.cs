using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
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

        public string? Gender { get; set; }
    }
}
