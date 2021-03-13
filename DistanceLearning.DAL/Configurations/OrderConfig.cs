using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => new {c.StudentId, c.CourseId});

            builder
                .HasOne(o => o.Course)
                .WithMany(c => c.Orders)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(o => o.Student)
                .WithMany(c => c.Orders)
                .HasForeignKey(l => l.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}