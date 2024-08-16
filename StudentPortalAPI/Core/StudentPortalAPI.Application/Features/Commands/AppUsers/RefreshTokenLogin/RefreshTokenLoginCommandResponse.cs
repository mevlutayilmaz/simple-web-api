using StudentPortalAPI.Application.DTOs;

namespace StudentPortalAPI.Application.Features.Commands.AppUsers.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDTO Token { get; set; }
    }
}
