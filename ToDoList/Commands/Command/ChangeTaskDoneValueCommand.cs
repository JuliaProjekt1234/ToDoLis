using MediatR;

namespace ToDoList.Commands.Command;

public class ChangeTaskDoneValueCommand : IRequest
{
    public int Id { get; set; }

    public ChangeTaskDoneValueCommand(int id)
    {
        Id = id;
    }
}
