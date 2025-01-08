namespace EMS.Infrastructure.Domain.Entities
{
    public class Course
    {
        public int Id { set; get; }
        public int Hours { set; get; }
        public string Code { set; get; }
        public string Level { set; get; }
        public int DepartmentId { set; get; }
        public Department Department { set; get; }
        public ICollection<Student> Students { set; get; } = new List<Student>();
        public ICollection<Instructor> Instructors { set; get; } = new List<Instructor>();
        public ICollection<StudentCourses> StudentCourses { set; get; } = new List<StudentCourses>();
        public ICollection<InstructorCourses> InstructorCourses { set; get; } = new List<InstructorCourses>();
    }
}
