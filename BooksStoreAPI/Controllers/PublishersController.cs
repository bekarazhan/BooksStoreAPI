using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::BooksStoreAPI.Core.Interfaces;
    using global::BooksStoreAPI.Core.Models.DTOs;

    namespace BooksStoreAPI.Controllers
    {
        public class PublisherController : BaseApiController
        {
            private readonly IPublisherService _publisherService;

            public PublisherController(IPublisherService publisherService)
            {
                _publisherService = publisherService;
            }

            // GET: api/Publisher
            [HttpGet]
            public async Task<ActionResult<IEnumerable<PublisherDto>>> GetPublishers()
            {
                var publishers = await _publisherService.GetAllPublishers();
                return Ok(publishers);
            }

            // GET: api/Publisher/5
            [HttpGet("{id}")]
            public async Task<ActionResult<PublisherDto>> GetPublisher(int id)
            {
                var publisher = await _publisherService.GetPublisherById(id);
                if (publisher == null)
                {
                    return NotFound();
                }

                return Ok(publisher);
            }

            // POST: api/Publisher
            [HttpPost]
            public async Task<ActionResult> PostPublisher(PublisherDto publisherDto)
            {
                var createdPublisher = await _publisherService.AddPublisher(publisherDto);
                return CreatedAtAction(nameof(GetPublisher), new { id = createdPublisher.Id }, createdPublisher);
            }

            // PUT: api/Publisher/5
            [HttpPut("{id}")]
            public async Task<ActionResult> PutPublisher(int id, PublisherDto publisherDto)
            {
                if (id != publisherDto.Id)
                {
                    return BadRequest("Publisher ID mismatch.");
                }

                await _publisherService.UpdatePublisher(publisherDto);
                return NoContent();
            }

            // DELETE: api/Publisher/5
            [HttpDelete("{id}")]
            public async Task<ActionResult> DeletePublisher(int id)
            {
                await _publisherService.DeletePublisher(id);
                return NoContent();
            }
        }
    }

}
