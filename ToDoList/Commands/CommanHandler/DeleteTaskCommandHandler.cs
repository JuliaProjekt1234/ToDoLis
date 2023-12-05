using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Repositories;

namespace ToDoList.Commands.CommanHandler;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITasksRepository _taskRepository;

    public DeleteTaskCommandHandler(ITasksRepository tasksRepository)
    {
        _taskRepository = tasksRepository;
    }
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var table = await _taskRepository.GetTask(request.Id);
        await _taskRepository.DeleteTask(table);
    }
}
