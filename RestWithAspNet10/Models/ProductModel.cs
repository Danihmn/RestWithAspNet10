using RestWithAspNet10.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet10.Models
{
    [Table("products")]
    public class ProductModel : ModelBase
    {
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(80)")]
        public string? Description { get; set; }

        [Required]
        [Column("brand", TypeName = "varchar(30)")]
        public string? Brand { get; set; }

        [Required]
        [Column("quantity_stock", TypeName = "int")]
        public int QuantityStock { get; set; }

        [Required]
        [Column("sale_price", TypeName = "decimal(10,2)")]
        public decimal SalePrice { get; set; }

        [Required]
        [Column("cost_price", TypeName = "decimal(10,2)")]
        public decimal CostPrice { get; set; }

        [Required] [Column("enabled")] public bool? Enabled { get; set; }
    }
}