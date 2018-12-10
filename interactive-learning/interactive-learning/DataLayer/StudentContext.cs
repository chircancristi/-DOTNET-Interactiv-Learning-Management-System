using Microsoft.EntityFrameworkCore;


namespace interactive_learning.DataLayer
{
    class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.Course).IsRequired();
        }
    }
}
