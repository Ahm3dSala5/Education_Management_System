using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Courses.Command.Request
{
    public class DeleteCourseCommand : IRequest<Result<string>>
    {
        public DeleteCourseCommand(int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
