using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public interface IPublisherRepositories
    {
         Task<IEnumerable<Publisher>> GetPublishers();
         Task<Publisher> GetPublisher(int Id);

         Task<Publisher> CreatePublisher(Publisher publisher);

         Task updatePublisher(Publisher publisher);

         Task<Publisher> deletePublisher(int Id);


    }
}
