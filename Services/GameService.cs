using game_shop.Data;
using game_shop.Dtos.Game;
using game_shop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace game_shop.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDBContext _context;
        private readonly IBlobService _blobService;

        public GameService(ApplicationDBContext context, IBlobService blobService)
        {
            this._context = context;
            this._blobService = blobService;
        }
        public async Task<Game> CreateAsync(Game game, IFormFile formFile)
        {
            var Uri = await _blobService.UploadAsync(formFile);
            game.Image = Uri;
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(s => s.Id == id);

            if (game == null) { return null; }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Game>>? GetByNameAsync(string name)
        {
            return await _context.Games.Where(g => EF.Functions.Like(g.Name.ToLower(), $"%{name.ToLower()}%")).ToListAsync();
        }

        public async Task<Game?> UpdateAsync(int id, UpdateRequestDto gameDto)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(s => s.Id == id);

            if (existingGame == null) { return null; }

            existingGame.Name = gameDto.Name;
            existingGame.Image = gameDto.Image;
            existingGame.Description = gameDto.Description;
            existingGame.Price = gameDto.Price;

            await _context.SaveChangesAsync();

            return existingGame;
        }
    }
}
