using EMS.API.MainControllers;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Core.Features.Departments.Query.Request;
using EMS.Infrastructure.Domain.DTOs.Department;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Department
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : MainController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DepartmentDTO department)
        {
            var Creation = await Mediator!.Send(new CreateDepartmentCommand(department));
            return Ok(HandlredResult(Creation));
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var Creation = await Mediator!.Send(new GetDepartmentByIdQuery(id));
            return Ok(HandlredResult(Creation));
        }
    }
}
