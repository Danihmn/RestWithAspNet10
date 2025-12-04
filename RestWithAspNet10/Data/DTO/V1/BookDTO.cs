using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
{
    public class BookDTO
    {
        [JsonPropertyName("identifier")]
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public decimal Price { get; set; }

        [JsonPropertyName("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
