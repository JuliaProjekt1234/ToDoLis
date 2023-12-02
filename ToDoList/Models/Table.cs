using Microsoft.Extensions.Hosting;

namespace ToDoList.Models;

public class Table
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
    public Table()
    {

    }
}
