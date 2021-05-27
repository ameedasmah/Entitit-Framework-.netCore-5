using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Helper;
using WebApplication1.models;
using WebApplication1.Repositories;
using WebApplication1.Resourse;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IAuthorBookeRepositoires _repository;
        public BookAuthorController(IAuthorBookeRepositoires repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book_AuthorsResourse>> GetBook_Authors()
        {
            var BookAuthorEntities =  await _repository.GetAuthor_Book();
            var bookResouces = new List<Book_AuthorsResourse>();
            foreach(var item in BookAuthorEntities)
            {
                bookResouces.Add(item.ToResource());
            }
            return bookResouces;
        }
        [HttpGet("{Id}")]
        public async Task<Book_AuthorsResourse> getId(int Id)
        {
            var entitityBookAuthor =  await _repository.GetAuthor_Books(Id);
            return entitityBookAuthor.ToResource();
        }

        [HttpPost]
        public async Task<ActionResult<Book_AuthorsResourse>> CreateItem([FromBody] Book_AuthorModel Entitiy)
        {
            var newCreateEntity = new Book_Author()
            {
                AuthorId = Entitiy.AuthorId,
                BookId = Entitiy.BookId
            };

            var AuthorBookntities = await _repository.CreateAuthor_Book(newCreateEntity);
            return CreatedAtAction(nameof(getId), new { Id = newCreateEntity.Id }, AuthorBookntities.ToResource());
        }
    }
}
