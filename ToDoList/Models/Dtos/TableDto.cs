namespace ToDoList.Models.Dtos;

public class TableDto: BaseTableDto
{
    public int Id { get; set; }

    public List<TaskDto> Tasks { get; set; }
}
