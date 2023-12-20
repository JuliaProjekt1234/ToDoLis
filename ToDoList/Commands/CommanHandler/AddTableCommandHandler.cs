using AutoMapper;
using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.Commands.CommanHandler;

public class AddTableCommandHandler : IRequestHandler<AddTableCommand>
{
    private readonly IMapper _mapper;
    private readonly ITablesRepository _tablesRepository;
    private readonly IUserHttpContextService _userHttpContextService;

    public AddTableCommandHandler(
        IMapper mapper,
        ITablesRepository tablesRepository,
        IUserHttpContextService userHttpContextService
        )
    {
        _mapper = mapper;
        _tablesRepository = tablesRepository;
        _userHttpContextService = userHttpContextService;
    }
    public async System.Threading.Tasks.Task Handle(AddTableCommand request, CancellationToken cancellationToken)
    {
        var table = _mapper.Map<Table>(request.TableDto);
        table.UserId = _userHttpContextService.GetUserId();
        await _tablesRepository.Add(table);
    }
}
