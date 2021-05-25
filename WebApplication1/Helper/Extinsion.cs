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
        public static PublisherResourse ToResourcePubl(this Publisher entituy)
        {
            return new PublisherResourse()
            {
                Id = entituy.Id,
                Name = entituy.Name
            };
        }
    }
}
