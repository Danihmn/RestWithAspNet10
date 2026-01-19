using RestWithAspNet10.Hypermedia;
using RestWithAspNet10.Hypermedia.Abstract;
using RestWithAspNet10.JsonConverters;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
{
    public record PersonDTO : ISupportHypermedia
    {
        [JsonPropertyName("identifier")] public long Id { get; init; }

        [JsonPropertyName("first_name")] public string? FirstName { get; init; }

        [JsonPropertyName("last_name")] public string? LastName { get; init; }

        public string? Address { get; init; }

        [JsonConverter(typeof(GenderConverter))]
        public string? Gender { get; init; }

        // Receives or sets the hypermedia links
        public List<HypermediaLink> Links { get; set; } = [];
    }
}