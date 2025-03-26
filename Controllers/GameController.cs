using game_shop.Data;
using Microsoft.AspNetCore.Mvc;
using game_shop.Mappers;
using game_shop.Services;
using Microsoft.AspNetCore.OutputCaching;
using game_shop.Dtos.Game;
using System.Text.Json;

namespace game_shop.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController(ApplicationDBContext context, IGameService gameService, IBlobService blobService) : ControllerBase
    {
        private readonly IGameService _gameService = gameService;
        private readonly IBlobService _lobService = blobService;
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        [OutputCache(PolicyName = "Cache45")]   
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var games = await _gameService.GetAllAsync();

            var sas = await _lobService.BlobSasBuilder();
            foreach (var game in games)
            {
                if (!string.IsNullOrEmpty(game.Image))
                {
                    game.Image = game.Image + "?" + sas;
                }
            }

            var gameDto = games.Select(s => s.ToGameDto());
            return Ok(gameDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var game = await _gameService.GetByIdAsync(id);

            if (game == null) { return NotFound(); }

            return Ok(game.ToGameDto());
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var game = await _gameService.GetByNameAsync(name);

            if (game == null) { return NotFound(); }

            return Ok(game.Select(s => s.ToGameDto()));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateRequestDto gameDto, IFormFile formFile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var JsonString = JsonSerializer.Serialize(formFile);
            gameDto.Image = JsonString;
            var game = gameDto.ToGameFromCreateDto();

            await _gameService.CreateAsync(game ,formFile);
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game.ToGameDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var game = await _gameService.UpdateAsync(id, updateDto);

            if (game == null) { return NotFound();}

            await _context.SaveChangesAsync();

            return Ok(game.ToGameDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var game = await _gameService.DeleteAsync(id);
            
            if (game == null) { return NotFound();}
            
            return NoContent();
        }
    }
}