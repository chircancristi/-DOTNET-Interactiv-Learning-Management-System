using Microsoft.EntityFrameworkCore;

namespace interactive_learning.DataLayer
{
    class ProfesorContext : DbContext
    {
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Profesor> Profesors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.Course).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.ListOfStudents).IsRequired();
        }
    }
}
