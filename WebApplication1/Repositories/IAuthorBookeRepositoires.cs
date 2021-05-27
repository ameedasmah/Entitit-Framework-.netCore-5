using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public interface IAuthorBookeRepositoires
    {
       public Task<IEnumerable<Book_Author>> GetAuthor_Book();
        public Task<Book_Author> CreateAuthor_Book(Book_Author book_Author);
        public Task<Book_Author> GetAuthor_Books(int Id);
    }
}
