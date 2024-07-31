using Application;
using Application.Application.Commands.Users;
using Application.Dtos.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost("UserRegister")]
    public async Task<ActionResult<ApplicationResponse<UserResponseDto>>> Register(UserRegisterDto dto) {
        var response = await _mediator.Send(new RegisterUserCommand(dto));

        //return response.Success ? Ok(response) : NotFound(response.Message);

        return Ok(response);
    }

    [HttpPost("UserLogin")]
    public async Task<ActionResult<ApplicationResponse<UserResponseDto>>> Login(UserLoginDto dto) {
        var response = await _mediator.Send(new LoginUserCommand(dto));

        //return response.Success ? Ok(response) : NotFound(response.Message);

        return Ok(response);
    }
}
