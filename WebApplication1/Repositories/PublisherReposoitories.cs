using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class PublisherReposoitories : IPublisherRepositories
    {
        private readonly BookContext _Context;
        public PublisherReposoitories(BookContext Context)
        {
            _Context = Context;
        }
        public async Task<Publisher> CreatePublisher(Publisher publisher)
        {
            _Context.Add(publisher);
            await _Context.SaveChangesAsync();
                return publisher;
        }

        public Task<Publisher> deletePublisher(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> GetPublisher(int Id)
        {
            return await _Context.publishers.Include(item=>item.Books).FirstOrDefaultAsync(x=>x.Id==Id);
        }

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return await _Context.publishers.Include(item=>item.Books).ToListAsync();
        }

        public async Task updatePublisher(Publisher publisher)
        {
            _Context.Entry(publisher).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }

    }
}
