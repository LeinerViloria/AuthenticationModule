
using System.ComponentModel.DataAnnotations;

namespace AuthenticationModule.Entities
{
    public abstract class BaseObj
    {
        [Key]
        public int Rowid {get; set;}
        [Required]
        public DateTime CreationDate {get; set;}
        public DateTime? LastUpdateDate {get; set;}
    }
}