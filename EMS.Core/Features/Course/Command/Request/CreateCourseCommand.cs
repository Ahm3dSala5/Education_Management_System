using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Course;
using MediatR;

namespace EMS.Core.Features.Courses.Command.Request
{
    public class CreateCourseCommand : IRequest<Result<string>>
    {
        public CreateCourseCommand(CreateCourseDTO course)
        {
            this.Hours = course.cour_Hours;
            this.Level = course.cour_Level;
            this.Code = course.cour_Code;
            this.DepartmentId = course.cour_DepartmentId;
        }
        public int Hours { set; get; }
        public string Code { set; get; }
        public string Level { set; get; }
        public int DepartmentId { set; get; }
    }
}
