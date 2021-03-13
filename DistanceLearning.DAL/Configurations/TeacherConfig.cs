using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasMany(l => l.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(l => l.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Email).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(z => z.Name).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Surname).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Password).IsRequired().HasMaxLength(30);
        }
    }
}