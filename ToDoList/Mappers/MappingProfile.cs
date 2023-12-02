using AutoMapper;
using ToDoList.Models;
using ToDoList.Models.Dtos;

namespace ToDoList.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Table, TableDto>()
                .ForMember(dst => dst.Tasks, opt => opt.MapFrom(src => src.Tasks
                .Select(task => new TaskDto()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Done = task.Done,
                })));

        CreateMap<TableDto, Table>();

        CreateMap<Table, BaseTableDto>();
        CreateMap<BaseTableDto, Table>();
        //.ForMember(dst => dst.Tasks, opt => opt.MapFrom(src => src.Tasks as ICollection<Task>));

        //CreateMap<TableDto, TableDto>();
    }

}
