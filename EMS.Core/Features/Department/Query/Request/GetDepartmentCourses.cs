using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Courses;
using EMS.Infrastructure.Domain.Entities;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetDepartmentCourses : IRequest<Response<List<CourseModel>>>
    {
        public GetDepartmentCourses(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
