using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Helper;
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
        public async Task<IEnumerable<NewBookResourse>> GetBooks()
        {
            var BookEntities = await _bookRepository.Get();
            var bookResources = new List<NewBookResourse>();
            foreach(var item in BookEntities)
            {
                bookResources.Add(item.ToResourceNew());
            }
                    return bookResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewBookResourse>> GetBooks(int id)
        {
            var BookEntities =  await _bookRepository.Get(id);
            if(BookEntities is null){
                return NotFound();
            }
            return BookEntities.ToResourceNew();
           


        }

        [HttpPost]

        public async Task<ActionResult<NewBookResourse>> PostBooks([FromBody] BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = new Book()
            {
                PublisherId= bookModel.PublisherId,
                Title=bookModel.Title,
                Discraptions = bookModel.Discraptions
            };

            var newBooksss = await _bookRepository.Create(newBook);

            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBooksss.ToResourceNew());
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<NewBookResourse>> PutBooks(int id, [FromBody] BookModel book)
        {


               var bookToUpdate = await _bookRepository.Get(id);
            if (bookToUpdate == null) { 
                return NotFound();
            }
            
            var newBook = new Book()
            {
                PublisherId = bookToUpdate.PublisherId,
                Title = bookToUpdate.Title,
                Discraptions= bookToUpdate.Discraptions
            };
               var BookEntities =  await _bookRepository.Update(newBook);
            var bookResources = BookEntities.ToResourceNew();
            return bookResources;





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
