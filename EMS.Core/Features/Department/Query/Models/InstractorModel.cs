using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Domain.DTOs.Instractors
{
    public class InstractorModel
    {
        public int inst_Id { set; get; }
        public string inst_Name { set; get; }
        public string inst_JobTitle { set; get; }
        public DateTime inst_HireDate { set; get; }
        public string inst_Address { set; get; }
        public decimal inst_Salary { set; get; }
        public int inst_DepartmentId { set; get; }
    }
}
