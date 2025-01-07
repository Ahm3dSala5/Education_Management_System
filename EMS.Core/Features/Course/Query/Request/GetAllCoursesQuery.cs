using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Courses.Query.Request
{
    public class GetAllCoursesQuery : IRequest<Result<ICollection<CourseModel>>>
    {
        public GetAllCoursesQuery()
        {

        }
    }
}
