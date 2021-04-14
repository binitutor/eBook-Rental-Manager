using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBook_Rental_Manager.Models
{
    public class Book
    {
        public int ID { get; set; }
        public byte[] ImageURL { get; set; }

        [Display(Name = "Book Title")]
        [Required] 
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [MinLength(10, ErrorMessage = "Your exerpt is short")]
        public string Excerpt { get; set; }
        [Display(Name = "Release Date")]

        [Required]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Rental Price")]
        [Required]
        public decimal RentalPrice { get; set; }
        public int? GenreID { get; set; } // foreign key for Genre
        public virtual Genre Genre { get; set; }

    }
}