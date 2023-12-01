using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;

namespace ToDoLists.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public Task<List<ToDoList.Models.Table>> GetTables()
        {
            return _tablesRepository.GetTables();
        }

        [HttpPut(nameof(AddTable))]
        public async Task AddTable([FromBody] TableDto tableDto)
        {
            await _tablesRepository.Add(_mapper.Map<Table>(tableDto));
        }
    }
}