using System.Data.Entity;

namespace Library.Contexts
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("BookCont")
        {
            Database.SetInitializer<BookContext>(new CreateDatabaseIfNotExists<BookContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(m => m.BookId).Property(m => m.BookId).IsRequired();

            modelBuilder.Entity<Book>().Property(p => p.BookName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Book>().Property(p => p.Description).HasMaxLength(50);

            modelBuilder.Entity<Book>().Property(p => p.IssueYear);

            modelBuilder.Entity<Book>().Property(p => p.PageNumber);
        }

        public DbSet<Book> Books { get; set; }
    }
}
