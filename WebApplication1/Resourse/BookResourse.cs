using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class BookResourse
    {
        public int Id { get; set; }
        public int? PublisherId { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        //public String Discraptions { get; set; }
    }
}
