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
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _reposotiry.GetAuthors();
        }
        [HttpGet("{id}")]
        public async Task<Author> GetAuthor(int Id)
        {
            return await _reposotiry.GetAuthor(Id);
        }
        [HttpPost]
        public async Task<ActionResult<AuthorResource>> CreateAuthor([FromBody] AuthorModel Entitiy)
        {
            var AuthEntitiy = new Author()
            {
                FullName = Entitiy.FullName,
            };
            var AuthortOEntities = await _reposotiry.CreateAuthor(AuthEntitiy);
            return CreatedAtAction(nameof(CreateAuthor), new { Id = AuthEntitiy.Id }, AuthortOEntities.ToResource());
        }



    }
}
