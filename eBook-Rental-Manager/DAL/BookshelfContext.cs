using eBook_Rental_Manager.Models;
using System.Data.Entity;

namespace eBook_Rental_Manager.DAL
{
    public class BookshelfContext : DbContext
    {
        //public DbSet<Book> Books { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        public BookshelfContext() : base("name=BookshelfContext")
        {
            Database.SetInitializer<BookshelfContext>(new DropCreateDatabaseIfModelChanges<BookshelfContext>());
        }
        public System.Data.Entity.DbSet<eBook_Rental_Manager.Models.Book> Books { get; set; }
        public System.Data.Entity.DbSet<eBook_Rental_Manager.Models.Genre> Genres { get; set; }
    }
}