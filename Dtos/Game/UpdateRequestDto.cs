using System.ComponentModel.DataAnnotations;

namespace game_shop.Dtos.Game
{
    public class UpdateRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
    }
}