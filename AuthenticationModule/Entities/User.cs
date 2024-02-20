
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
        [StringLength(14, MinimumLength = 5, ErrorMessage = "The password must have between 5 and 14 characters.")]
        public string Password {get; set;}
    }
}