using RestWithAspNet10.JsonConverters;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
{
    public record ProductDTO
    {
        [JsonPropertyName("identifier")]
        public long Id { get; init; }

        public string? Name { get; init; }

        public string? Description { get; init; }

        public string? Brand { get; init; }

        [JsonPropertyName("quantity_stock")]
        public int QuantityStock { get; init; }

        [JsonPropertyName("cost_price")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal CostPrice { get; init; }

        [JsonPropertyName("sale_price")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenReading)]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal SalePrice { get; init; }

        public bool? Enabled { get; set; }
    }
}
