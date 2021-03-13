﻿using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Teacher)
                .WithMany(l => l.Courses)
                .HasForeignKey(l => l.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Orders)
                .WithOne(sc => sc.Course)
                .HasForeignKey(o => o.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(z => z.Name).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Description).IsRequired().HasMaxLength(1000);
            builder.Property(z => z.Theme).IsRequired().HasMaxLength(100);
            builder.Property(z => z.PersonQuantity).IsRequired();
            builder.Property(z => z.StartDate).IsRequired();
            builder.Property(z => z.EndDate).IsRequired();
            builder.Property(z => z.TotalLessonsQuantity).IsRequired();
        }
    }
}