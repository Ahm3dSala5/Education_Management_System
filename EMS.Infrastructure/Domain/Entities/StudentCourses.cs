namespace EMS.Infrastructure.Domain.Entities
{
    public class StudentCourses
    {
        public int StudentId { set; get; }
        public Student Student { set; get; }
        public int CourseId { set; get; }
        public Course Course { set; get; }
    }
}
