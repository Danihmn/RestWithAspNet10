using RestWithAspNet10.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet10.Models
{
    [Table("person")]
    public class PersonModel : ModelBase
    {
        [Required]
        [Column("first_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string? FirstName { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string? LastName { get; set; }

        [Required]
        [Column("address", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        [Column("gender", TypeName = "varchar(60)")]
        [MaxLength(60)]
        public string? Gender { get; set; }

        //[NotMapped]
        //public DateTime? BirthDay { get; set; }
    }
}
