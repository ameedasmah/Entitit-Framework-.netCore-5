using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Resourse;

namespace WebApplication1.Helper
{
    public static class Extinsion
    {
        public static BookResourse ToResource(this Book entitiy)
        {
            return new BookResourse()
            {
                Id = entitiy.Id,
                Author = entitiy.Author,
                PublisherId = entitiy.PublisherId,
                Title = entitiy.Title
            };
        }

        public static List<BookResourse> ToResource(this List<Book> entities)
        {
            var response = new List<BookResourse>();
            foreach(var item in entities)
            {
                response.Add(item.ToResource());
            }
            return response;
        }

        public static PublisherResourse ToResource(this Publisher entities)
        {
            return new PublisherResourse()
            {
                Id = entities.Id,
                Name = entities.Name,
                Books = entities.Books?.ToResource()
            };
        }
    }
}
