using Application;
using Application.Dtos.Users;

namespace BlazorUI.Services.User;

public interface IUserService
{
    Task<ApplicationResponse<UserResponseDto>> Login(UserLoginDto dto);
    Task<ApplicationResponse<UserResponseDto>> Register(UserRegisterDto dto);
}
