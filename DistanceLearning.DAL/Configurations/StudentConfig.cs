using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Email).IsRequired().HasMaxLength(40);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(z => z.Name).IsRequired().HasMaxLength(30);
            builder.Property(z => z.Surname).IsRequired().HasMaxLength(40);
            builder.Property(z => z.Password).IsRequired().HasMaxLength(40);

            builder
                .HasMany(s => s.Orders)
                .WithOne(c => c.Student)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(s => s.Id);
        }
    }
}