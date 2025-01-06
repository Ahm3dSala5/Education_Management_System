using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Students;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Model
{
    public class GetDepartmentStudents: IRequest<Response<List<StudentModel>>>
    {
        public GetDepartmentStudents(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
