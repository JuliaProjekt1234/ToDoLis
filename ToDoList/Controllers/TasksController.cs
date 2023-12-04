using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;

namespace ToDoLists.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TablesController> _logger;
    private readonly ITasksRepository _tasksRepository;
    private readonly IMapper _mapper;

    public TasksController(
        IMapper mapper,
        ILogger<TablesController> logger,
        ITasksRepository tasksRepository
        )
    {
        _mapper = mapper;
        _logger = logger;
        _tasksRepository = tasksRepository;
    }

    [HttpPut(nameof(AddTask))]
    public async Task AddTask([FromBody] BaseTaskDto taskDto)
    {
        await _tasksRepository.AddNewTask(_mapper.Map<ToDoList.Models.Task>(taskDto));
    }
}