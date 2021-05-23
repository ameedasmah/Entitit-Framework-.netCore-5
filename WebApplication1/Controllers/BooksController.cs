using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]

        public async Task<ActionResult<BookResourse>> PostBooks([FromBody] BookModel bookModel)
        {

            var newBook = new Book()
            {
                //Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Discraptions = bookModel.Discraptions
            };

            var newBooksss = await _bookRepository.Create(newBook);

            var newBookResp = new BookResourse()
            {
                //Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
            };

            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBookResp);
        }
        [HttpPut("{id}")]

        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            await _bookRepository.Update(book);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
      
                return NotFound();
            
            await _bookRepository.Delete(bookToDelete.Id);
                return NoContent();
        }

    }
}
