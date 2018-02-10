using System.ComponentModel.DataAnnotations;

namespace ITGigs.WebApp.DTOs
{
    public class LoginEntry
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
