using AutoMapper;
using MediatR;
using ToDoList.Commands.Command;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.Commands.CommanHandler;

public class GetTablesCommandHandler : IRequestHandler<GetTablesCommand, List<TableDto>>
{
    private readonly IMapper _mapper;
    private readonly ITablesRepository _tablesRepository;
    private readonly IUserHttpContextService _userHttpContextService;

    public GetTablesCommandHandler(
    IMapper mapper,
    ITablesRepository tablesRepository,
    IUserHttpContextService userHttpContextService)
    {
        _mapper = mapper;
        _tablesRepository = tablesRepository;
        _userHttpContextService = userHttpContextService;
    }

    public async Task<List<TableDto>> Handle(GetTablesCommand request, CancellationToken cancellationToken)
    {
        var userId = _userHttpContextService.GetUserId();
        var tables = await _tablesRepository.GetTables(userId);
        return _mapper.Map<List<TableDto>>(tables);
    }
}
