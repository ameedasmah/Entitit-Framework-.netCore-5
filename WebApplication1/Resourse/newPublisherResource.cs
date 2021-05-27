using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Resourse
{
    public class newPublisherResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookResourse> Books { get; set; }
    }
}
