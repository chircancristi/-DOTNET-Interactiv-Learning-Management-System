using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CoursesContext : DbContext
    {
        /*
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        */
        public CoursesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                Database=Courses;Trusted_Connection=True;");

            }
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<StudentCourseRelationship> StudentCourseRelationships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<Room>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<StudentCourseRelationship>().Property(t => t.Id).IsRequired();
        }
    }
}
