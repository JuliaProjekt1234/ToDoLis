using Microsoft.AspNetCore.Mvc;
using ToDoList.Db;
using ToDoList.Models.Dtos;

namespace ToDoList.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly IToDoListDbContext _dbContext;

    public TasksRepository(IToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddNewTask(Models.Task task)
    {
        await _dbContext.AddEntity(task);
    }
}
