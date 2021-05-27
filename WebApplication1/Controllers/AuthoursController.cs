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
    public class AuthoursController : ControllerBase
    {
        private readonly IAuthorRepositories _reposotiry;

        public AuthoursController(IAuthorRepositories reposotiry)
        {
            _reposotiry = reposotiry;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorResource>> GetAuthors()
        {
            var AuthorEntities =  await _reposotiry.GetAuthors();

            var ResponseAuthor = new List<AuthorResource>();

            foreach(var item in AuthorEntities)
            {
                ResponseAuthor.Add(item.ToResource());
            }
            return ResponseAuthor;

        }
        [HttpGet("{id}")]
        public async Task<AuthorResource> GetAuthor(int id)
        {
           var AuthorEntitiy =  await _reposotiry.GetAuthor(id);

            return AuthorEntitiy.ToResource();
        }
        [HttpPost]
        public async Task<ActionResult<AuthorResource>> CreateAuthor([FromBody] AuthorModel Entitiy)
        {
            var AuthEntitiy = new Author()
            {
                FullName = Entitiy.FullName,
            };
            var AuthortOEntities = await _reposotiry.CreateAuthor(AuthEntitiy);
            return CreatedAtAction(nameof(GetAuthor), new { id = AuthortOEntities.Id }, AuthortOEntities.ToResource());
        }

        [HttpPut("{Id}")]

        public async Task<ActionResult> PutAuthor(int Id, [FromBody] AuthorModel authorModel)
        {
            var authorEntities = new Author()
            {
                FullName = authorModel.FullName,
            };
            var AuthorUpdateEntitiy = _reposotiry.Update(authorEntities);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _reposotiry.GetAuthor(id);
            if (bookToDelete == null)

                return NotFound();

            await _reposotiry.Delete(bookToDelete.Id);
            return NoContent();
        }


    }
}
