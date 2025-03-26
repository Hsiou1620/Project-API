using game_shop.Dtos.Game;
using game_shop.Models;

namespace game_shop.Mappers
{
    public static class GameMapper
    {
        public static GameDto ToGameDto(this Game game) 
        {
            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Image = game.Image,
                Description = game.Description,
                Price = game.Price
            };
        }

        public static Game ToGameFromCreateDto(this CreateRequestDto gameDto)
        {
            return new Game
            {
                Name = gameDto.Name,
                Image = gameDto.Image,
                Description = gameDto.Description,
                Price = gameDto.Price
            };
        }

    }
}
