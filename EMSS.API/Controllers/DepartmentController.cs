using EMS.API.MainControllers;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Core.Features.Departments.Query.Request;
using EMS.Infrastructure.Domain.DTOs.Department;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : MainController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DepartmentDTO department)
        {
            var Creation = await Mediator!.Send(new CreateDepartmentCommand(department));
            return Ok(HandledResult(Creation));
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var department = await Mediator!.Send(new GetDepartmentByIdQuery(id));
            return Ok(HandledResult(department));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await Mediator!.Send(new GetAllDepartmentQuery());
            return Ok(HandledResult(departments));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentUpdateDTO department)
        {
            var updating = await Mediator!.Send(new UpdateDepartmentCommand(department));
            return Ok(HandledResult(updating));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleting = await Mediator!.Send(new DeleteDepartmentCommand(id));
            return Ok(HandledResult(deleting));
        }
    }
}
