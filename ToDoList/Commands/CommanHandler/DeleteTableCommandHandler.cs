using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Repositories;

namespace ToDoList.Commands.CommanHandler;

public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand>
{
    private readonly ITablesRepository _tablesRepository;

    public DeleteTableCommandHandler(ITablesRepository tablesRepository)
    {
        _tablesRepository = tablesRepository;
    }
    public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _tablesRepository.GetTable(request.Id);
        await _tablesRepository.DeleteTable(table);
    }
}
