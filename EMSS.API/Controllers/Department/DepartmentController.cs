using EMS.Core.Features.Departments.Command.Request;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Department
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(DepartmentDTO department)
        {
            return Ok(await _mediator.Send(new CreateDepartmentCommand(department)));
        }
    }
}
