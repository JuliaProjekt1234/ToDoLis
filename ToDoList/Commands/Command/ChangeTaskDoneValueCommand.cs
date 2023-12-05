using MediatR;

namespace ToDoList.Commands.Command;

public class ChangeTaskDoneValueCommand : IRequest
{
    public int Id { get; }

    public ChangeTaskDoneValueCommand(int id)
    {
        Id = id;
    }
}
