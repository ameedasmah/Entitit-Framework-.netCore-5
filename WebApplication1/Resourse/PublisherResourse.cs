using System.Collections.Generic;
using WebApplication1.Data;

namespace WebApplication1.Resourse
{
    public class PublisherResourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookResourse> Books { get; set; }
    }
}
