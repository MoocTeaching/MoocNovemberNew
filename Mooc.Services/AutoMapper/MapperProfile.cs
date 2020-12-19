using AutoMapper;
using Mooc.Dtos.User;
using Mooc.Dtos.Teacher;
using Mooc.Models.Entities;

namespace Mooc.Services.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<User, UserDto>().ForMember(c => c.Email111, p => p.MapFrom(x => x.Email));
            CreateMap<User, UserDto>();
            CreateMap<CreateOrUpdateUserDto, User>();

            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateOrUpdateTeacherDto, Teacher>();

        }
    }
}