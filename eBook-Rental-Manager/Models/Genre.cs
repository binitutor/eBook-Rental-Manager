using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBook_Rental_Manager.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Display(Name = "Book Genre")]
        public string GenreName { get; set; }
        public virtual ICollection<Book> Books { get; set; } // foreign key that links Books and Genre
    }
}