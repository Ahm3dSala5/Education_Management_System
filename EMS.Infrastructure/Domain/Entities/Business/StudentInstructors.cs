namespace EMS.Infrastructure.Domain.Entities
{
    public class StudentInstructors
    {
        public int StudentId { set; get; }
        public Student Student { set; get; }
        public int InstructorId { set; get; }
        public Instructor Instructor { set; get; }
    }
}
