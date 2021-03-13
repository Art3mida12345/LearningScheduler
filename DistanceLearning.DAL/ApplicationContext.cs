using DistanceLearning.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DistanceLearning.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<StudentScheduleRequest> StudentScheduleRequest { get; set; }

        public DbSet<TeacherScheduleRequest> TeacherScheduleRequest { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Lesson> Lesson { get; set; }
    }
}