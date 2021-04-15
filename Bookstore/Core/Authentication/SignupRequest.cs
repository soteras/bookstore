using Bookstore.Core.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Authentication
{
    public class SignupRequest
    {
        [Required]
        [StringLength(300)]
        [EmailUserUniqueAttribute]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
