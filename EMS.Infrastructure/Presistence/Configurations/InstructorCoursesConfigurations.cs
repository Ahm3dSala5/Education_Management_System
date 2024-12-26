using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class InstructorCoursesConfigurations : IEntityTypeConfiguration<InstructorCourses>
    {
        public void Configure(EntityTypeBuilder<InstructorCourses> builder)
        {
            builder.ToTable("InstructorCourses").HasKey(X => new { X.InstructorId, X.CourseId });
        }
    }
}
