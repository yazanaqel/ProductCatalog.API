using Application.Dtos.Users;
using Application.Entities.Users;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Users;

public record LoginUserCommand(UserLoginDto Dto) : IRequest<ApplicationResponse<UserResponseDto>>;

public class LoginUserHandler(IUserService userService, IMapper mapper) : IRequestHandler<LoginUserCommand, ApplicationResponse<UserResponseDto>> {
    private readonly IUserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<UserResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken) {

        var user = _mapper.Map<ApplicationUser>(request.Dto);

        var result = await _userService.LoginAsync(user);

        var response = _mapper.Map<ApplicationResponse<UserResponseDto>>(result);

        return response;

    }
}