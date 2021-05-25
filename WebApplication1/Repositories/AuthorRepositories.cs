using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class AuthorRepositories:IAuthorRepositories
    {
        private readonly BookContext _bookContext;

        public AuthorRepositories(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
             _bookContext.Authors.Add(author);
            await _bookContext.SaveChangesAsync();
            return author;
            
        }

        public async Task<Author> GetAuthor(int Id)
        {
            return await _bookContext.Authors.FindAsync(Id);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _bookContext.Authors.ToListAsync();
        }

        public async Task Update(Author author)
        {
            _bookContext.Entry(author).State = EntityState.Modified;
            await _bookContext.SaveChangesAsync();
        }
    }
}
