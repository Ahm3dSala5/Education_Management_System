using EMS.Core.Features.Departments.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Request
{
    public class GetAllDepartmentQuery :IRequest<Result<List<DepartmentModel>>>
    {

    }
}
