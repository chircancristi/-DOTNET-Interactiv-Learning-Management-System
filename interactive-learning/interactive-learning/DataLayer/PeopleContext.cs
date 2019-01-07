using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PeopleContext : DbContext
    {
        /*
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        */
        public PeopleContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                Database=People;Trusted_Connection=True;");

            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Profesor> Profesors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Profesor>().Property(t => t.Course).IsRequired();

            modelBuilder.Entity<Student>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.LastName).IsRequired();
        }
    }
}
