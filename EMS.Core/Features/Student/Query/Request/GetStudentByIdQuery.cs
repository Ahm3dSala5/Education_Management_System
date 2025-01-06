using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Students.Query.Request
{
    public class GetStudentByIdQuery :IRequest<Result<StudentModel>>
    {
        public GetStudentByIdQuery(int id )
        {
            this.std_Id = id;
        }
        public int std_Id { set; get; }
    }
}
