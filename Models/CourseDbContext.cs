using Microsoft.EntityFrameworkCore;
using TrainingManagement.CourseApi.Data;

namespace TrainingManagement.CourseApi.Models
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasData(new List<Course> { 
                new Course(){
                    CourseID=new Random().Next(1,Int32.MaxValue/2),
                    CourseName="ASP.NET Core",
                    CourseDescription="ASP.NET Core Training L1",
                    Duration=10
                }
            });
        }
    }
}
