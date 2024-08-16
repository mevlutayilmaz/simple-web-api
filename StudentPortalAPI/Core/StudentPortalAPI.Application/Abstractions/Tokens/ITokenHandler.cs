using StudentPortalAPI.Application.DTOs;
using StudentPortalAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Abstractions.Tokens
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
