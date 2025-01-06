using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Students.Query.Request
{
    public class GetAllStudentsQuery : 
        IRequest<Result<ICollection<StudentModel>>>
    {

    }
}
