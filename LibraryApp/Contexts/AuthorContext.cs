using System.Data.Entity;

namespace Library.Contexts
{
    public class AuthorContext : DbContext
    {
        public AuthorContext()
            : base("AuthorCont")
        {
            Database.SetInitializer<AuthorContext>(new CreateDatabaseIfNotExists<AuthorContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(m => m.AuthorId).Property(m => m.AuthorId).IsRequired();

            modelBuilder.Entity<Author>().Property(p => p.AuthorName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Author>().Property(p => p.BirthDate).HasMaxLength(50);
        }

        public DbSet<Author> Authors { get; set; }
    }
}
