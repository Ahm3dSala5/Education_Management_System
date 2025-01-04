﻿using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Students;
using EMS.Infrastructure.Domain.Entities;
using MediatR;

namespace EMS.Core.Features.Students.Command.Request
{
    public class CreateStudentCommand : IRequest<Response<string>>
    {
        public CreateStudentCommand(StudentDTO student)
        {
            this.Age = student.std_age;
            this.FirstName = student.std_FName;
            this.LastName = student.std_LName;
            this.Address = student.std_address;
            this.GPA = student.std_GPA;
            this.Level = student.std_level;
            this.DepartmentId = student.std_deptId;
            this.BirthDate = student.std_birthDate;
        }
        public int Age { set; get; }
        public int Level { set; get; }
        public double GPA { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime BirthDate { set; get; }
        public string Address { set; get; }
        public int DepartmentId { set; get; }
    }
}