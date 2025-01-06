using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Instractors;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Model
{
    public class GetDepartmentInstractors : IRequest<Response<List<InstractorModel>>>
    {
        public GetDepartmentInstractors(int _id)
        {
            this.dept_Id = _id;
        }
        public int dept_Id { private set; get; }
    }
}
