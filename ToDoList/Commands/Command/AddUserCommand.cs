using MediatR;
using ToDoList.Models.Dtos;

namespace ToDoList.Commands.Command;

public class AddUserCommand : IRequest
{
    public UserToAddDto User { get; }

    public AddUserCommand(UserToAddDto user)
    {
        User = user;
    }
}
