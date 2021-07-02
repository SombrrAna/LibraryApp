using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Contexts
{
    public class AuthorBookContext : DbContext
    {
        public AuthorBookContext()
            : base("AuthorBookCont")
        {
            Database.SetInitializer<AuthorBookContext>(new CreateDatabaseIfNotExists<AuthorBookContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>().Property(m => m.AuthorId).IsRequired();

            modelBuilder.Entity<AuthorBook>().Property(p => p.BookId).IsRequired();
        }

        public DbSet<AuthorBook> AuthorBooks { get; set; }
    }
}
