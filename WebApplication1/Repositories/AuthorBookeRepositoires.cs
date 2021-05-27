using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class AuthorBookeRepositoires: IAuthorBookeRepositoires
    {
        private readonly BookContext _ContexrBookAuthor;
        public AuthorBookeRepositoires(BookContext ContexrBookAuthor)
        {
            _ContexrBookAuthor = ContexrBookAuthor;
        }

        public async Task<Book_Author> CreateAuthor_Book(Book_Author book_Author)
        {
            _ContexrBookAuthor.book_Authors.Add(book_Author);
            await _ContexrBookAuthor.SaveChangesAsync();
            return book_Author;
        }

        public async Task<IEnumerable<Book_Author>> GetAuthor_Book()
        {
            return await _ContexrBookAuthor.book_Authors.ToListAsync();
        }

        public async Task<Book_Author> GetAuthor_Books(int Id)
        {
            return await _ContexrBookAuthor.book_Authors.FindAsync(Id);
        }
    }
}

