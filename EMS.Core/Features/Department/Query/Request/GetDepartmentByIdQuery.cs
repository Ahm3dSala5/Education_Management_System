using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetDepartmentByIdQuery :IRequest<Response<DepartmentDTO>>
    {
        public GetDepartmentByIdQuery(int _id)
        {
            this.Id = _id;
        }
        public int Id { private set; get; }
    }
}
