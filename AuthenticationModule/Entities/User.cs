
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Entities
{
    [Index(nameof(Email), Name = "Ix_User__Email", IsUnique = true)]
    public class User : BaseObj
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
    }
}