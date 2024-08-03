using Application;
using Application.Dtos.Users;
using System.Net.Http.Json;

namespace BlazorUI.Services.User;

public class UserService(HttpClient httpClient) : IUserService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationResponse<UserResponseDto>> Login(UserLoginDto dto)
    {
        var response = new ApplicationResponse<UserResponseDto>();

        try
        {
            var result = await _httpClient.PostAsJsonAsync("api/User/UserLogin",dto);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<UserResponseDto>>();

            if(data is not null)
            {
                return data;
            }

        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

    public async Task<ApplicationResponse<UserResponseDto>> Register(UserRegisterDto dto)
    {
        var response = new ApplicationResponse<UserResponseDto>();

        try
        {
            var result = await _httpClient.PostAsJsonAsync("api/User/UserRegister",dto);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<UserResponseDto>>();

            if(data is not null)
            {
                return data;
            }
        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }
}
