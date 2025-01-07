using EMS.Core.Features.Instructors.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Courses.Query.Request
{
    public class GetCourseInstructorsQuery : IRequest<Result<ICollection<InstractorModel>>>
    {
        public GetCourseInstructorsQuery( int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
