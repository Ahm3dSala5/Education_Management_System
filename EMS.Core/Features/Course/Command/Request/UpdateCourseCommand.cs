using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Course;
using MediatR;

namespace EMS.Core.Features.Courses.Command.Request
{
    public class UpdateCourseCommand : IRequest<Result<string>>
    {
        public UpdateCourseCommand(UpdateCourseDTO course)
        {
            this.Id = course.cour_Id;
            this.Hours = course.cour_Hours;
            this.Level = course.cour_Level;
            this.Code = course.cour_Code;
            this.DepartmentId = course.cour_DepartmentId;
        }

        public int Id { set; get; }
        public int Hours { set; get; }
        public string Code { set; get; }
        public string Level { set; get; }
        public int DepartmentId { set; get; }
    }
}
