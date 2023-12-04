namespace ToDoList.Repositories;

public interface ITasksRepository
{
    Task AddNewTask(ToDoList.Models.Task task);
}
