using System.ComponentModel.DataAnnotations;

namespace ITGigs.WebApp.DTOs
{
    public class LoginEntry
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
