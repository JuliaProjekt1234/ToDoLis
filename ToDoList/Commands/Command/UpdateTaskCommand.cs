using MediatR;
using ToDoList.Models.Dtos;

namespace ToDoList.Commands.Command;

public class UpdateTaskCommand : IRequest
{
    public TaskToUpdateDto TaskToUpdate { get; set; }

    public UpdateTaskCommand(TaskToUpdateDto taskToUpdate)
    {
        TaskToUpdate = taskToUpdate;
    }
}
