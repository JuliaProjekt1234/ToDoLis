namespace ToDoList.Models.Dtos;

public class BaseTaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public int TableId { get; set; }
}
