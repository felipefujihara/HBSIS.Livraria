using HBSIS.Livraria.Domain;
using Microsoft.EntityFrameworkCore;

namespace HBSIS.Livraria.Infra.Dal.Context
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HbsisDb;Trusted_Connection=True;");
        //}
    }
}
