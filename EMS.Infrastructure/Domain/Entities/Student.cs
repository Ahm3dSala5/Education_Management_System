namespace EMS.Infrastructure.Domain.Entities
{
    public class Student
    {
        public int Id { set; get; }
        public int Age { set; get; }
        public int Level { set; get; }
        public double GPA { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime BirthDate { set; get; }
        public string Address { set; get; }
        public Department Department { set; get; }
        public int DepartmentId { set; get; }
        public ICollection<Course> Courses { set; get; } = new List<Course>();
        public ICollection<StudentCourses> StudentCourses { set; get; } = new List<StudentCourses>();
        public ICollection<StudentInstructors> StudentInstructors { set; get; } = new List<StudentInstructors>();
        public ICollection<Instructor> Instructors { set; get; } = new List<Instructor>();
    }
}
