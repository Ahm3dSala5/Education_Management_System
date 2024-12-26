namespace EMS.Infrastructure.Domain.Entities
{
    public class Room
    {
        public int Id { set; get; }
        public int Capacity { set; get; }
        public string Name { set; get; }
        public Department Department {set;get;}
        public int DepartmentId {set;get;}
        public ICollection<Instructor> Instructors { set; get; } = new List<Instructor>();
        public ICollection<InstructorRooms> InstructorRooms { set; get; } = new List<InstructorRooms>();
    }
}
