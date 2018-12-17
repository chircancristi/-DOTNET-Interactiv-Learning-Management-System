using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class InteractionContext : DbContext
    {
        /*
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        */
        public InteractionContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                Database=Interaction;Trusted_Connection=True;");

            }
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<Answer>().Property(t => t.Id).IsRequired();
        }
    }
}
