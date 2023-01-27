using Students.Entities.Configuration;
using Students.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Students.Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());






        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<MountedCourse>? MountedCourses { get; set; }
        public DbSet<Programme>? Programmes { get; set; }
        public DbSet<Level>? Levels { get; set; }
        public DbSet<Calender>? Calenders { get; set; }

        public DbSet<Event>? Events { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<AcademicRecord>? AcademicRecords { get; set; }
        public DbSet<TeachingTimeTable>? TeachingTimeTables { get; set; }

        public DbSet<ExamTimeTable>? ExamTimeTables { get; set; }

        public DbSet<Bills>? Bills { get; set; }

    }
}
