using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eBook_Rental_Manager.Data
{
    public class eBook_Rental_ManagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eBook_Rental_ManagerContext() : base("name=eBook_Rental_ManagerContext")
        {
            Database.SetInitializer<eBook_Rental_ManagerContext>(new DropCreateDatabaseIfModelChanges<eBook_Rental_ManagerContext>());
        }

        public System.Data.Entity.DbSet<eBook_Rental_Manager.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<eBook_Rental_Manager.Models.Genre> Genres { get; set; }
    }
}
