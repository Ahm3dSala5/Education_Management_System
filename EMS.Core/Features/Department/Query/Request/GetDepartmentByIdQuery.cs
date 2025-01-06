using EMS.Core.Features.Departments.Query.Model;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetDepartmentByIdQuery :IRequest<Result<DepartmentModel>>
    {
        public GetDepartmentByIdQuery(int _id)
        {
            this.Id = _id;
        }
        public int Id { private set; get; }
    }
}
