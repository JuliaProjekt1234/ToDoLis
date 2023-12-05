namespace ToDoList.Repositories;

public interface ITasksRepository
{
    public Task AddNewTask(ToDoList.Models.Task task);
    public ValueTask<Models.Task> GetTask(int id);
    public Task UpdateTask(Models.Task task);
    public Task DeleteTask(Models.Task task);
}
