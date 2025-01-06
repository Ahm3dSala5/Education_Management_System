using EMS.Core.Features.Instructors.Query.Model;
using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Students.Query.Request
{
    public class GetStudentInstructorsQuery : IRequest<Result<ICollection<InstractorModel>>>
    {
        public GetStudentInstructorsQuery(int id)
        {
            this.std_Id = id;
        }
        public int std_Id { set; get; }
    }
}
