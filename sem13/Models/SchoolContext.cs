using Microsoft.EntityFrameworkCore;

namespace sem13.Models
{
    public class SchoolContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB1504-26\\SQLEXPRESS;Initial Catalog=taipedb;User ID=torres;Password=12345;trustservercertificate=True"
                );
        }

    }
}
