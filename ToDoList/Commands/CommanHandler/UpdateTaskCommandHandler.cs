using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Repositories;

namespace ToDoList.Commands.CommanHandler;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITasksRepository _taskRepository;

    public UpdateTaskCommandHandler(ITasksRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTask(request.TaskToUpdate.Id);
        task.Name = request.TaskToUpdate.Name;
        task.Description = request.TaskToUpdate.Description;
        await _taskRepository.UpdateTask(task);
    }
}
