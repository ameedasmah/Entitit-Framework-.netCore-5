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

            return await _Context.Books.Include(X => X.Publisher).FirstOrDefaultAsync(X => X.Id == book.Id);
        }

        public async Task Delete(int Id)
        {
            var bookToDelete = await _Context.Books.Include(x => x.book_Authors).FirstOrDefaultAsync(X => X.Id == Id);
            _Context.Remove(bookToDelete);

            await _Context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Get()
        {
            try
            {

            return await _Context.Books.Include(x=>x.book_Authors).Include(X => X.Publisher).ToListAsync();
            }
            catch(Exception exiption)
            {
                throw new Exception($" there is no Book to retrive {exiption.Message}");
            }
        }

        public async Task<Book> Get(int Id)
        {
            try
            {

            return await _Context.Books.Include(X => X.Publisher).FirstOrDefaultAsync(X => X.Id == Id);
            }
            catch(Exception exiption)
            {
                throw new Exception($"there is no Book to retrive {exiption.Message}");
            }
        }

        public async Task<Book> Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} must not be null");
            }
            try
            {

            _Context.Entry(book).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            return await _Context.Books.Include(X => X.Publisher).FirstOrDefaultAsync(X => X.Id == book.Id); 
            }
            catch(Exception ex)
            {
                throw new Exception($"coulen't update book :{ex.Message}");
            }

        }

    }
        }

