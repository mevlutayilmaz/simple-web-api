using Microsoft.AspNetCore.Identity;
using StudentPortalAPI.Application.Abstractions.Services;
using StudentPortalAPI.Application.Abstractions.Tokens;
using StudentPortalAPI.Application.DTOs;
using StudentPortalAPI.Application.Exceptions;
using StudentPortalAPI.Domain.Entities.Identity;

namespace StudentPortalAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<TokenDTO> LoginAsync(string UserNameOrEmail, string Password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(UserNameOrEmail);
            if (user == null)
                throw new Exception("Kullanıcı adı ya da şifre hatalı");
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            if (result.Succeeded)
            {
                // Yetkilerin(Authorization) belirlenmesi gerekiyor.
                TokenDTO token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);

                return new()
                {
                    AccessToken = token.AccessToken,
                    Expiration = token.Expiration,
                    RefreshToken = token.RefreshToken,
                };
            }
            throw new AuthenticationErrorExcaption();
        }

        public async Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);

            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(900, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new Exception("Kullanıcı bulunamadı!");
        }
    }
}
