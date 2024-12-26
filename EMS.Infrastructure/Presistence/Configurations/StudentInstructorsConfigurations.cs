using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class StudentInstructorsConfigurations : IEntityTypeConfiguration<StudentInstructors>
    {
        public void Configure(EntityTypeBuilder<StudentInstructors> builder)
        {
            builder.ToTable("StudentInstructors").HasKey((X => new { X.StudentId, X.InstructorId }));

        }
    }
}
