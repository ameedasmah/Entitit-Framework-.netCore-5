using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properites
        
        public List<Book> Books { get; set; }
    }
}
