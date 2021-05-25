using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Entities
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }

         



    }
}
