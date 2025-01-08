namespace EMS.Infrastructure.Domain.Entities
{
    public class InstructorCourses
    {
        public int InstructorId { set; get; }
        public Instructor Instructor { set; get; }
        public int CourseId { set; get; }
        public Course Course { set; get; }
    }
}
