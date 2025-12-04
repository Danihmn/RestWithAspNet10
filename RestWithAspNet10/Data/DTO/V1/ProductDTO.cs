using System.Text.Json.Serialization;

namespace RestWithAspNet10.Data.DTO.V1
{
    public class ProductDTO
    {
        [JsonPropertyName("identifier")]
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Brand { get; set; }

        [JsonPropertyName("quantity_stock")]
        public int QuantityStock { get; set; }

        [JsonPropertyName("cost_price")]
        public decimal CostPrice { get; set; }

        [JsonPropertyName("sale_price")]
        public decimal SalePrice { get; set; }
    }
}
