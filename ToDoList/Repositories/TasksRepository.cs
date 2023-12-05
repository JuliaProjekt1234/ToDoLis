using ToDoList.Db;

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

    public ValueTask<Models.Task> GetTask(int id) 
    {
        return _dbContext.GetEntity<Models.Task>(id);
    }

    public Task UpdateTask(Models.Task task)
    {
        return _dbContext.UpdateEntity(task);
    }

    public Task DeleteTask(Models.Task task)
    {
        return _dbContext.DeleteEntity(task);
    }

}
