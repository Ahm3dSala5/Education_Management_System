namespace EMS.Infrastructure.Domain.Entities
{
    public class Instructor
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string JobTitle { set; get; }
        public DateTime HireDate { set; get; }
        public string Address { set; get; }
        public decimal Salary { set; get; }
        public int DepartmentId { set; get; }
        public Department Department { set; get; }
        public ICollection<Student> Students { set; get; } = new List<Student>();
        public ICollection<Room> Rooms { set; get; } = new List<Room>();
        public ICollection<Course> Courses { set; get; } = new List<Course>();
        public ICollection<InstructorCourses> InstructorCourses { set; get; } = new List<InstructorCourses>();
        public ICollection<StudentInstructors> StudentInstructors { set; get; } = new List<StudentInstructors>();
        public ICollection<InstructorRooms> InstructorRooms { set; get; } = new List<InstructorRooms>();
    }
}
