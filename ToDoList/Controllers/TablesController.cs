using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;

namespace ToDoLists.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TablesController : ControllerBase
{
    private readonly ILogger<TablesController> _logger;
    private readonly ITablesRepository _tablesRepository;
    private readonly IMapper _mapper;

    public TablesController(
        IMapper mapper,
        ILogger<TablesController> logger,
        ITablesRepository tablesRepository
        )
    {
        _mapper = mapper;
        _logger = logger;
        _tablesRepository = tablesRepository;
    }

    [HttpGet(nameof(GetTables))]
    public async Task<List<TableDto>> GetTables()
    {
        return _mapper.Map<List<TableDto>>((await _tablesRepository.GetTables()));
    }

    [HttpPut(nameof(AddTable))]
    public System.Threading.Tasks.Task AddTable([FromBody] BaseTableDto tableDto)
    {
        return _tablesRepository.Add(_mapper.Map<Table>(tableDto));
    }

    [HttpGet(nameof(GetTable) + "/{id}")]
    public async ValueTask<TableDto> GetTable([FromRoute] int id)
    {
        return _mapper.Map<TableDto>(await _tablesRepository.GetTable(id));
    }
}