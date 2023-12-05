using MediatR;

namespace ToDoList.Commands.Command;

public class DeleteTableCommand: IRequest
{
    public int Id { get; }

	public DeleteTableCommand(int id)
	{
		Id = id;
	}
}
