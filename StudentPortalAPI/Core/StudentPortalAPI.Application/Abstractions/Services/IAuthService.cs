using StudentPortalAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> LoginAsync(string UserNameOrEmail, string Password, int accessTokenLifeTime);
        Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken);
    }
}
