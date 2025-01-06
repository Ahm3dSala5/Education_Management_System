using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;

namespace EMS.Core.Features.Departments.Command.Request
{
    public class UpdateDepartmentCommand : IRequest<Result<string>>
    {
        public UpdateDepartmentCommand(DepartmentUpdateDTO department)
        {
            this.Name = department.dept_Name;
            this.Manager = department.dept_Manager;
            this.Id = department.dept_Id;
        }

        public int Id { set; get; }
        public string Name { set; get; }
        public string Manager { set; get; }
    }
}
