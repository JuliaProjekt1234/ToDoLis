
namespace ToDoList.Models;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }

    public int TableId { get; set; }
    public virtual Table Table { get; set; } = null!;

    public Task()
    {

    }

}
