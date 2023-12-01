using AutoMapper;
using ToDoList.Models;
using ToDoList.Models.Dtos;

namespace ToDoList.Mappers;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Table, TableDto>();
        CreateMap<TableDto, Table>();
    }
}
