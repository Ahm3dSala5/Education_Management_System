namespace EMS.Infrastructure.Domain.Entities
{
    public class Department
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Manager { set; get; }
        public ICollection<Student> Students { set; get; } = new List<Student>();
        public ICollection<Course> courses { set; get; } = new List<Course>();
        public ICollection<Instructor> Instructors { set; get; } = new List<Instructor>();
        public ICollection<Room> Rooms { set; get; } = new List<Room>();
    }
}
