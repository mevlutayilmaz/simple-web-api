using MediatR;
using StudentPortalAPI.Application.Abstractions.Services;
using StudentPortalAPI.Application.DTOs;

namespace StudentPortalAPI.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO token = await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 900);
            return new()
            {
                Token = token,
            };
        }
    }
}
