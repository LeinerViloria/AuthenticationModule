
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationModule.Entities
{
    public abstract class BaseObj
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rowid {get; set;}

        [Required]
        public DateTime CreationDate {get; set;}

        public DateTime? LastUpdateDate {get; set;}
    }
}