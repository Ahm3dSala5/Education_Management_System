using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.Entities;
using MediatR;

namespace EMS.Core.Features.Courses.Query.Request
{

    public class GetCourseStudentsQuery : IRequest<Result<ICollection<StudentModel>>>
    {
        public GetCourseStudentsQuery(int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
