using game_shop.Dtos.Account;

namespace game_shop.Services
{
    public interface IAccountService
    {
        Task<NewUserDto> SignupAsync(SignupDto registerDto);
        Task<NewUserDto> LoginAsync(LoginDto loginDto);
    }
}
