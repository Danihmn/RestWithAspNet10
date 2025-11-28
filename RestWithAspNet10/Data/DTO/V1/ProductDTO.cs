namespace RestWithAspNet10.Data.DTO.V1
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public int QuantityStock { get; set; }
        public decimal CostPrice { get; set; }
    }
}
