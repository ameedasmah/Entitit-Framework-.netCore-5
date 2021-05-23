using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public class BookRepositories : IBookRepository
    {

        private readonly BookContext _Context;

        public BookRepositories(BookContext Context)
        {
            _Context = Context;

                }
        public async Task<Book> Create(Book book)
        {
            _Context.Books.Add(book);

            await _Context.SaveChangesAsync();

            return book;

        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _Context.Books.FindAsync(id);
             _Context.Remove(bookToDelete);

            await _Context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _Context.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _Context.Books.FindAsync(Id);
        }

        public async Task Update(Book book)
        {
            _Context.Entry(book).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
        }

