using AutoMapper;
using MediatR;
using StudentPortalAPI.Application.Abstractions.Services;
using StudentPortalAPI.Application.DTOs.Users;

namespace StudentPortalAPI.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        readonly IUserService _userService;
        readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDTO response = await _userService.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
            });

            return new()
            {
                Succeeded = response.Succeeded,
                Message = response.Message,
            };
        }
    }
}
