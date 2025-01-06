using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Students.Query.Request
{
    public class GetStudentCoursesQuery : IRequest<Result<ICollection<CourseModel>>>
    {
        public GetStudentCoursesQuery(int id)
        {
            this.std_Id = id;
        }
        public int std_Id { set; get; }
    }
}
