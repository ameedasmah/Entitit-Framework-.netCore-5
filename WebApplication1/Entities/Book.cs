using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class Book
    {
        public int Id {get; set;}
        public String Title { get; set; }
        public String Author { get; set; }
        public String Discraptions { get; set; }

        //Navigation Properites
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> boook_Authors { get; set; }


    }
}
