using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Commands.Command;
using ToDoList.Models.Dtos;
using ToDoList.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoLists.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TasksController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger<TablesController> _logger;
    private readonly ITasksRepository _tasksRepository;

    public TasksController(
        IMapper mapper,
        IMediator mediator,
        ILogger<TablesController> logger,
        ITasksRepository tasksRepository
        )
    {
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
        _tasksRepository = tasksRepository;
    }

    [HttpPost(nameof(AddTask))]
    public async Task AddTask([FromBody] BaseTaskDto taskDto)
    {
        await _tasksRepository.AddNewTask(_mapper.Map<ToDoList.Models.Task>(taskDto));
    }

    [HttpGet(nameof(ChangeTaskDoneValue) + "/{id}")]
    public async Task ChangeTaskDoneValue([FromRoute] int id)
    {
        await _mediator.Send(new ChangeTaskDoneValueCommand(id));
    }

    [HttpDelete(nameof(DeleteTask) + "/{id}")]
    public async Task DeleteTask([FromRoute] int id)
    {
        await _mediator.Send(new DeleteTaskCommand(id));
    }

    [HttpPut(nameof(UpdateTask))]
    public async Task UpdateTask([FromBody] TaskToUpdateDto taskToUpdateDto)
    {
        await _mediator.Send(new UpdateTaskCommand(taskToUpdateDto));
    }
}