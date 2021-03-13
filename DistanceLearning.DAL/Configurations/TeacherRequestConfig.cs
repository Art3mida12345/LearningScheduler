using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class TeacherRequestConfig : IEntityTypeConfiguration<TeacherScheduleRequest>
    {
        public void Configure(EntityTypeBuilder<TeacherScheduleRequest> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(a => a.Teacher)
                .WithMany(p => p.TeacherScheduleRequests)
                .HasForeignKey(k => k.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}