using EMS.API.MainControllers;
using EMS.Core.Features.Departments.Query.Model;
using EMS.Core.Features.Students.Command.Request;
using EMS.Infrastructure.Domain.DTOs.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : MainController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(StudentModel student)
        {
            var creationResult = await _mediator.Send(new CreateStudentCommand(student));
            return HandledResult(creationResult);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateStudentDTO student)
        {
            var updationResult = await _mediator.Send(new UpdateStudentCommand(student));
            return HandledResult(updationResult);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletionResult = await _mediator.Send(new DeleteStudentCommand(id));
            return HandledResult(deletionResult);
        }
    }
}
