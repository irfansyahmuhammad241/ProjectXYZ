using System.ComponentModel.DataAnnotations;

namespace Technical_Test.DTOs.Authorization
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
