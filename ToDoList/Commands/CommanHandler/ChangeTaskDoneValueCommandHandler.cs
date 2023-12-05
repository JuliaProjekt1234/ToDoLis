using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Repositories;

namespace ToDoList.Commands.CommanHandler;

public class ChangeTaskDoneValueCommandHandler : IRequestHandler<ChangeTaskDoneValueCommand>
{
    private readonly ITasksRepository _taskRepository;

    public ChangeTaskDoneValueCommandHandler(ITasksRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    async Task IRequestHandler<ChangeTaskDoneValueCommand>.Handle(ChangeTaskDoneValueCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTask(request.Id);
        task.Done = !task.Done;
        await _taskRepository.UpdateTask(task);
    }
}
