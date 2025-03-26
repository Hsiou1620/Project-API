using System.ComponentModel.DataAnnotations;

namespace game_shop.Dtos.Account
{
    public class SignupDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
