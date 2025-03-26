using System.ComponentModel.DataAnnotations;

namespace game_shop.Dtos.Game
{
    public class CreateRequestDto
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Title cannot be over 200 characters")]
        public  string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Required]

        [MaxLength(200, ErrorMessage = "Description cannot be over 200 characters")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(1, 500)]
        public double Price { get; set; }
    }
}
