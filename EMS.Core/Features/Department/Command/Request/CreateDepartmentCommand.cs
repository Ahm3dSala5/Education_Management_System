﻿using EMS.Core.Features.Departments.Query.Model;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using MediatR;
namespace EMS.Core.Features.Departments.Command.Request
{
    public class CreateDepartmentCommand : IRequest<Result<string>>
    {
        public CreateDepartmentCommand(DepartmentModel department)
        {
            this.Name = department.dept_Name;
            this.Manager = department.dept_Manager;
        }
        public string Name { set; get; }
        public string Manager { set; get; }
    }
}
