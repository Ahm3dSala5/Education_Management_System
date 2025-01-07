using AutoMapper;
using EMS.Core.Features.Courses.Command.Request;
using EMS.Infrastructure.Domain.Entities;
using Microsoft.Identity.Client;
namespace EMS.Core.Mapping.Courses
{
    public partial class CourseProfile 
    {
        public void CreateCourseCommandMapping()
        {
            CreateMap<Course, CreateCourseCommand>()
                .ForMember(des => des.Code, src => src.MapFrom(x => x.Code))
                .ForMember(des => des.Hours, src => src.MapFrom(x => x.Hours))
                .ForMember(des => des.Level, src => src.MapFrom(x => x.Level))
                .ForMember(des => des.DepartmentId, src => src.MapFrom(x => x.DepartmentId)).ReverseMap();
        }

        public void UpdateCourseCommandMapping()
        {
            CreateMap<Course, UpdateCourseCommand>()
                .ForMember(des => des.Id, src => src.MapFrom(x => x.Id))
                .ForMember(des => des.Code, src => src.MapFrom(x => x.Code))
                .ForMember(des => des.Hours, src => src.MapFrom(x => x.Hours))
                .ForMember(des => des.Level, src => src.MapFrom(x => x.Level))
                .ForMember(des => des.DepartmentId, src => src.MapFrom(x => x.DepartmentId)).ReverseMap();
        }
    }
}
