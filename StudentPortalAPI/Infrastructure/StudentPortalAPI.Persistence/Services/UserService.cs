using Azure.Core;
using Microsoft.AspNetCore.Identity;
using StudentPortalAPI.Application.Abstractions.Services;
using StudentPortalAPI.Application.DTOs.Users;
using StudentPortalAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO user)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = user.NameSurname,
                Email = user.Email,
                UserName = user.UserName,
            }, user.Password);
            if (result.Succeeded)
                return new()
                {
                    Succeeded = result.Succeeded,
                    Message = "Kullanıcı başarıyla oluşturuldu."
                };
            return new()
            {
                Succeeded = result.Succeeded,
                Message = result.Errors.First().Description
            };
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if(user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("Kullanıcı bulunamadı!");
        }
    }
}
