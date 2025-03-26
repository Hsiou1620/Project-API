using game_shop.Models;

namespace game_shop.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, string userRole);
    }
}
