using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Resourse;

namespace WebApplication1.Data
{
    public class BookResourse
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public int discraptions { get; set; }
        public int? PublisherId { get; set; }

        public PublisherResourse publisherResourse  { get; set; }
       
    }
}
