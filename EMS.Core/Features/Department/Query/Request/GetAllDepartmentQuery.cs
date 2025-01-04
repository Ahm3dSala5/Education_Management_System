using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetAllDepartmentQuery :IRequest<Response<List<DepartmentDTO>>>
    {

    }
}
