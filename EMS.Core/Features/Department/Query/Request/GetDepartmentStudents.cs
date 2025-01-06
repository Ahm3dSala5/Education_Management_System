using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Model
{
    public class GetDepartmentStudents: IRequest<Result<List<StudentModel>>>
    {
        public GetDepartmentStudents(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
