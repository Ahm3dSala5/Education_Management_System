﻿using EMS.Core.Response;
using MediatR;

namespace EMS.Core.Features.Departments.Command.Request
{
    public class DeleteDepartmentCommand :IRequest<Response<string>>
    {
        public DeleteDepartmentCommand(int id)
        {
            this.Id = id;
        }
        public int Id { set; get; }
    }
}
