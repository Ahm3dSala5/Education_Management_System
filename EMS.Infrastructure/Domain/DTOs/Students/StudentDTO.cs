using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Domain.DTOs.Students
{
    public class StudentDTO
    {
        public int std_age { set; get; }
        public int std_level { set; get; }
        public double std_GPA { set; get; }
        public string std_FName { set; get; }
        public string std_LName { set; get; }
        public DateTime std_birthDate { set; get; }
        public string std_address { set; get; }
        public int std_deptId { set; get; }
    }
}
