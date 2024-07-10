using Abrar_Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Abrar_Bookstore.Data
{
    public class BookstoreDbContxt : DbContext
    {
        public BookstoreDbContxt(DbContextOptions<BookstoreDbContxt> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> book { get; set; }
        public DbSet<Author> author { get; set; }
    }
}
