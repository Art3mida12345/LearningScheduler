using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class StudentRequestConfig : IEntityTypeConfiguration<StudentScheduleRequest>
    {
        public void Configure(EntityTypeBuilder<StudentScheduleRequest> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(a => a.Student)
                .WithMany(p => p.StudentScheduleRequests)
                .HasForeignKey(k => k.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}