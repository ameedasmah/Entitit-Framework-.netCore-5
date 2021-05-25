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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepositories _repository;
        public PublisherController(IPublisherRepositories repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return await _repository.GetPublishers();
        }

        [HttpGet("{id}")]

        public async Task<Publisher> GetPublisher(int id)
        {
            return await _repository.GetPublisher(id);
        }

        [HttpPost]
        public async Task<ActionResult<PublisherResourse>> CreatePublisher([FromBody] PublisherModel newPublisherModel)
        {
            var newPublisherEntity = new Publisher()
            {
                Name = newPublisherModel.Name,
            };

            var newPublisher = await _repository.CreatePublisher(newPublisherEntity);

            return  CreatedAtAction(nameof(GetPublisher),new { Id= newPublisherEntity.Id }, newPublisher.ToResourcePubl());
        }
        [HttpPut("{id}")]

        public async Task<ActionResult> PutPublisher(int id, [FromBody] Publisher publisher)
        {
            await _repository.updatePublisher(publisher);

            return NoContent();
        } 
}}
