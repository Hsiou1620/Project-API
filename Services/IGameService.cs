using game_shop.Dtos.Game;
using game_shop.Models;

namespace game_shop.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);   
        Task<List<Game>>? GetByNameAsync(string name);
        Task<Game> CreateAsync(Game game, IFormFile formFile);
        Task<Game?> UpdateAsync(int id, UpdateRequestDto gameDto);
        Task<Game?> DeleteAsync(int id);
    }
}
