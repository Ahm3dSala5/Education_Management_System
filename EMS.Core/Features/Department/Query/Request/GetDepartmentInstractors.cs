using EMS.Core.Features.Instructors.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Model
{
    public class GetDepartmentInstractors : IRequest<Result<List<InstractorModel>>>
    {
        public GetDepartmentInstractors(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
