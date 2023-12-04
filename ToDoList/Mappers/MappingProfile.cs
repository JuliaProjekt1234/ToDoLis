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

        CreateMap<TaskDto, Models.Task>();
        CreateMap<Models.Task, TaskDto>();

        CreateMap<Models.Task, BaseTaskDto>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dst => dst.TableId, opt => opt.MapFrom(src => src.TableId))
            .ForMember(dst => dst.Done, opt => opt.MapFrom(src => src.Done));

        CreateMap<BaseTaskDto, Models.Task>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dst => dst.TableId, opt => opt.MapFrom(src => src.TableId))
            .ForMember(dst => dst.Done, opt => opt.MapFrom(src => src.Done));

    }

}
