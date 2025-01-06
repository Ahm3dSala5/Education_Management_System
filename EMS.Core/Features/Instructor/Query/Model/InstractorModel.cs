namespace EMS.Core.Features.Instructors.Query.Model
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
