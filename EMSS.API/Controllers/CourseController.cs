using EMS.API.MainControllers;
using EMS.Core.Features.Courses.Command.Request;
using EMS.Core.Features.Courses.Query.Request;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/Course")]
    public class CourseController : MainController
    {
        private readonly IMediator _Mediator;
        public CourseController(IMediator mediator)
        {
            this._Mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCourseDTO course)
        {
            var creation = await _Mediator.Send(new CreateCourseCommand(course));
            return HandledResult(creation);
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var course = await _Mediator.Send(new GetCourseByIdQuery(id));
            return HandledResult(course);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _Mediator.Send(new GetAllCoursesQuery());
            return HandledResult(courses);
        }

        [HttpGet("Students/{id}")]
        public async Task<IActionResult>GetStudents(int id )
        {
            var students = await _Mediator.Send(new GetCourseStudentsQuery(id));
            return HandledResult(students);
        }

        [HttpGet("Instructors/{id}")]
        public async Task<IActionResult> GetInstructors(int id)
        {
            var instructors = await _Mediator.Send(new GetCourseInstructorsQuery(id));
            return HandledResult(instructors);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCourseDTO course)
        {
            var updating = await _Mediator.Send(new UpdateCourseCommand(course));
            return HandledResult(updating);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleting = await _Mediator.Send(new DeleteCourseCommand(id));
            return HandledResult(deleting);
        }
    }
}
