using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet10.Models
{
    [Table("books")]
    public class BookModel
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("title", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        [Column("author", TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string? Author { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }

}
