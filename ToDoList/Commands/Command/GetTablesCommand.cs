using MediatR;
using ToDoList.Models.Dtos;

namespace ToDoList.Commands.Command;

public class GetTablesCommand: IRequest<List<TableDto>>
{
}
