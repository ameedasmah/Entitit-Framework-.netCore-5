using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class Book
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Required(ErrorMessage = "It's not allowed to be null")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "It's not allowed to be null")]
        [MaxLength(50)]
        //public String Author { get; set; }
        public string Discraptions { get; set; }
        [Required(ErrorMessage = "It's not allowed to be null")]

        //Navigation Properites
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        public List<Book_Author> book_Authors { get; set; }


    }
}
