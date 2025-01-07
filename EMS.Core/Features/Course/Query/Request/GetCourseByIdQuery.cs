using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Courses.Query.Request
{
    public class GetCourseByIdQuery : IRequest<Result<CourseModel>>
    {
        public GetCourseByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
