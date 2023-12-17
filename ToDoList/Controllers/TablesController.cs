using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Commands.Command;
using ToDoList.Models;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;

namespace ToDoLists.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TablesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger<TablesController> _logger;
    private readonly ITablesRepository _tablesRepository;

    public TablesController(
        IMapper mapper,
        IMediator mediator,
        ILogger<TablesController> logger,
        ITablesRepository tablesRepository
        )
    {
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
        _tablesRepository = tablesRepository;
    }

    [HttpGet(nameof(GetTables))]
    public async Task<List<TableDto>> GetTables()
    {
        return _mapper.Map<List<TableDto>>((await _tablesRepository.GetTables()));
    }

    [HttpPost(nameof(AddTable))]
    public System.Threading.Tasks.Task AddTable([FromBody] BaseTableDto tableDto)
    {
        return _tablesRepository.Add(_mapper.Map<Table>(tableDto));
    }

    [HttpGet(nameof(GetTable) + "/{id}")]
    public async ValueTask<TableDto> GetTable([FromRoute] int id)
    {
        return _mapper.Map<TableDto>(await _tablesRepository.GetTable(id));
    }

    [HttpDelete(nameof(DeleteTable) + "/{id}")]
    public async System.Threading.Tasks.Task DeleteTable([FromRoute] int id)
    {
        await _mediator.Send(new DeleteTableCommand(id));
    }

    [HttpPut(nameof(UpdateTable))]
    public async System.Threading.Tasks.Task UpdateTable([FromBody] TableDto tableDto)
    {
        await _tablesRepository.UpdateTable(_mapper.Map<Table>(tableDto));
    }

    [HttpPost(nameof(GetFilteredTable))]
    public async Task<List<TableDto>> GetFilteredTable([FromBody] FilterTableDto filterTableDto)
    {
        return _mapper.Map<List<TableDto>>(await _tablesRepository.GetFilteredTables(filterTableDto));
    }
}