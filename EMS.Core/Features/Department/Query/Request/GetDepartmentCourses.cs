using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetDepartmentCourses : IRequest<Result<List<CourseModel>>>
    {
        public GetDepartmentCourses(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
