using MediatR;

namespace ToDoList.Commands.Command;

public class DeleteTaskCommand: IRequest
{
    public int Id { get; }

	public DeleteTaskCommand(int id)
	{
		Id = id;
	}
}
