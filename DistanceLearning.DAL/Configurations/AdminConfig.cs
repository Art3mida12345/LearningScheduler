using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanceLearning.DAL.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder
                .HasOne(a => a.CreatedByPerson)
                .WithMany()
                .HasForeignKey(p => p.CreatedByPersonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(s => s.Id);

            builder.Property(c => c.Email).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(z => z.Name).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Surname).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Password).IsRequired().HasMaxLength(30);
        }
    }
}