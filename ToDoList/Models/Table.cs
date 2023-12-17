using Microsoft.Extensions.Hosting;

namespace ToDoList.Models;

public class Table: BaseEntity
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    public Table()
    {

    }
}
