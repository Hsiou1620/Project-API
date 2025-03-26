using game_shop.Dtos.Account;
using game_shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace game_shop.Services
{
    public class AccountService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService) : IAccountService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<NewUserDto> LoginAsync(LoginDto loginDto)
        {
            if (loginDto == null) {  throw new ArgumentNullException(nameof(loginDto)); }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null) { throw new UnauthorizedAccessException("Invalid UserName!"); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) { throw new UnauthorizedAccessException("Username not found and/or Passwor is invalid"); }

            var roles = await _userManager.GetRolesAsync(user);

            string userRole = roles.FirstOrDefault();

            return new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user, userRole),
                Roles = userRole
            };
        }

        public async Task<NewUserDto> SignupAsync(SignupDto registerDto)
        {
            if (registerDto == null) { throw new ArgumentNullException(nameof(registerDto)); }

            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

            if (createdUser.Succeeded) 
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                
                if (!roleResult.Succeeded) throw new Exception("Fail to add role");

                string userRole = "User";

                return new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user, userRole),
                    Roles = userRole
                };
            }
            throw new Exception(string.Join(", ", createdUser.Errors));
        }
    }
}
