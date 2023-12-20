using MediatR;
using ToDoList.Models.Dtos;

namespace ToDoList.Commands.Command;

public class AddTableCommand : IRequest
{
    public BaseTableDto TableDto { get; set; }

    public AddTableCommand(BaseTableDto tableDto)
    {
        TableDto = tableDto;
    }
}
