using AutoMapper;
using EMS.Core.Features.Instructors.Query.Model;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Instructors
{
    public partial class InstructorsProfile 
    {
        public void GetInstructorsMapping()
        {
            CreateMap<InstractorModel, Instructor>().
                ForMember(x => x.Id, x => x.MapFrom(x => x.inst_Id)).
                ForMember(x => x.DepartmentId, x => x.MapFrom(x => x.inst_DepartmentId)).
                ForMember(x => x.Name, x => x.MapFrom(x => x.inst_Name)).
                ForMember(x => x.Salary, x => x.MapFrom(x => x.inst_Salary)).
                ForMember(x => x.Address, x => x.MapFrom(x => x.inst_Address)).
                ForMember(x => x.JobTitle, x => x.MapFrom(x => x.inst_JobTitle)).
                ForMember(x => x.HireDate, x => x.MapFrom(x => x.inst_HireDate)).ReverseMap();
        }
    }
}
