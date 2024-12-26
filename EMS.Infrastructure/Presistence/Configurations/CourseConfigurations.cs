using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{

    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course").HasKey(x => x.Id);

            //department
            builder.HasOne(x => x.Department)
                .WithMany(x => x.courses)
                .HasForeignKey(x => x.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
