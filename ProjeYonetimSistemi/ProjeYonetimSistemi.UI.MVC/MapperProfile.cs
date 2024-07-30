using AutoMapper;
using ProjeYonetimSistemi.UI.MVC.Dto.Project;
using ProjeYonetimSistemi.UI.MVC.Dto.Task;
using ProjeYonetimSistemi.UI.MVC.Entity;

namespace ProjeYonetimSistemi.UI.MVC
{
    public class MapperProfile : Profile

    {
        public MapperProfile()
        {
            CreateMap<TaskEntity, addTaskDto>();
            CreateMap<addTaskDto, TaskEntity>();

            CreateMap<TaskEntity, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, TaskEntity>();

            CreateMap<ProjectEntity, addProjectDto>();
            CreateMap<addProjectDto, ProjectEntity>();
        }
    }
}
