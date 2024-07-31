using Application.Dtos.Users;
using Application.Entities.Users;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Users;

public record RegisterUserCommand(UserRegisterDto Dto) : IRequest<ApplicationResponse<UserResponseDto>>;

public class RegisterUserHandler(IUserService userService, IMapper mapper) : IRequestHandler<RegisterUserCommand, ApplicationResponse<UserResponseDto>> {
    private readonly IUserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<UserResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken) {

        var newUser = _mapper.Map<ApplicationUser>(request.Dto);

        newUser.UserName = request.Dto.Email;

        var result = await _userService.RegisterAsync(newUser);

        var response = _mapper.Map<ApplicationResponse<UserResponseDto>>(result);

        return response;
    }
}
