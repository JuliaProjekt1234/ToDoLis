using MediatR;
using ToDoList.Models.Dtos;

namespace ToDoList.Commands.Command;

public class LoginUserCommand : IRequest<string>
{
    public UserDto UserDto { get; set; }

	public LoginUserCommand(UserDto userDto)
	{
		UserDto = userDto;
	}
}
