namespace EMS.Infrastructure.Domain.DTOs.Courses
{
    public class CourseModel
    {
        public int cou_Id { set; get; }
        public int cou_Hours { set; get; }
        public string cou_Code { set; get; }
        public string cou_Level { set; get; }
        public int cou_DepartmentId { set; get; }
    }
}
