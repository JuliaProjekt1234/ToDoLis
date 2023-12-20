using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos;
using ToDoList.Commands.Command;

namespace ToDoList.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(nameof(RegisterUser))]
    public async Task RegisterUser([FromBody] UserToAddDto userDto)
    {
       await _mediator.Send(new AddUserCommand(userDto));    
    }
    
    [HttpPost(nameof(Login))]
    public async Task<string> Login([FromBody] UserDto userDto)
    {
      return await _mediator.Send(new LoginUserCommand(userDto));    
    }
}
