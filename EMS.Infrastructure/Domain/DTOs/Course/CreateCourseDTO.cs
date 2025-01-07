namespace EMS.Infrastructure.Domain.DTOs.Course
{
    public class CreateCourseDTO
    {
        public int cour_Hours { set; get; }
        public string cour_Code { set; get; }
        public string cour_Level { set; get; }
        public int cour_DepartmentId { set; get; }
    }
}
