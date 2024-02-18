
using System.ComponentModel.DataAnnotations;

namespace AuthenticationModule.Entities
{
    public class User : BaseObj
    {
        [Required]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
    }
}