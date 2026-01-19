using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
{
    public record BookDTO
    {
        [JsonPropertyName("identifier")] public long Id { get; init; }

        public string? Title { get; init; }

        public string? Author { get; init; }

        public decimal Price { get; init; }

        [JsonPropertyName("launch_date")] public DateTime LaunchDate { get; init; }
    }
}