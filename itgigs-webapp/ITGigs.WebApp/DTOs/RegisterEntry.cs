using System.ComponentModel.DataAnnotations;

namespace ITGigs.WebApp.DTOs
{
    public class RegisterEntry
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
