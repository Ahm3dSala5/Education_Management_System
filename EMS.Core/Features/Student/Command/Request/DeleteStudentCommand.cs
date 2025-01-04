using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Students.Command.Request
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
