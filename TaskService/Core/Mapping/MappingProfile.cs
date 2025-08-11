using AutoMapper;
using TaskService.Contracts.Entities;
using TaskService.Data.Models;

namespace TaskService.Core.Mapping
{
    public class MappingProfile: Profile
    {

        
        

        public MappingProfile() {

            //CreateMap<UserDTO, User>()
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            // .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
            // .ForMember(dest => dest.Email, opt => opt.MapFrom(opt => opt.Email))
            // .ForMember(dest => dest.CreatedAt,  opt => opt.MapFrom(opt=> opt.CreatedAt));
    
            
                

            

            CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
            
            CreateMap<User,UserDTO>();


            CreateMap<CreateTaskDTO, TaskModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(opt => DateTime.UtcNow))
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedAt, opt => opt.Ignore());

            

            CreateMap<TaskModel,TaskModelDTO>();    
            
            
        }
        
        
    }
}
