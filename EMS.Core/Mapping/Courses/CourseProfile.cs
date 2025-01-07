using AutoMapper;
namespace EMS.Core.Mapping.Courses
{
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            GetCoursesMapping();
            CreateCourseCommandMapping();
            UpdateCourseCommandMapping();
        }
    }
}
