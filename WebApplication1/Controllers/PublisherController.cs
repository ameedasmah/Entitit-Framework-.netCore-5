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
        public async Task<IEnumerable<PublisherResourse>> GetPublishers()
        {
            var PublisherEntities=  await _repository.GetPublishers();

            var publisherResource = new List<PublisherResourse>();

            foreach (var item in PublisherEntities)
            {
                publisherResource.Add(item.ToResource());
            }
            return publisherResource;
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

            return  CreatedAtAction(nameof(GetPublisher),new { Id= newPublisherEntity.Id }, newPublisher.ToResource());
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<PublisherResourse>> PutPublisher(int id, [FromBody] PublisherModel model)
        {
            var existingEntity = await _repository.GetPublisher(id);
            if (existingEntity == null) { return NotFound(); }

            existingEntity.Name = model.Name;
            var updatedEntity = await _repository.updatePublisher(existingEntity);
            return Ok(updatedEntity.ToResource());
        } 
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteResource(int Id)
        {
            var BookToDelete = await _repository.GetPublisher(Id);
            if (BookToDelete is null) return NotFound();
            
            await _repository.deletePublisher(BookToDelete.Id);
            return NoContent();
        }
}}
