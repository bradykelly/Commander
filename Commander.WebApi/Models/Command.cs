using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.WebApi.Models
{
    [Table("commands")]
    public class Command
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("howto")]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        [Column("line")]
        public string Line { get; set; }
        [Required]
        [Column("platform")]
        public string Platform { get; set; }
    }
}