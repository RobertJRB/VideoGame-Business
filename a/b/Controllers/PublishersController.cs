using Microsoft.AspNetCore.Mvc;
using VideoGame.API.DTOs;
using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                return NotFound($"Publisher with id {id} not found.");

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var publisher = new Publisher
            {
                Name = dto.Name,
                Website = dto.Website
            };

            await _publisherRepository.AddAsync(publisher);
            return CreatedAtAction(nameof(GetById), new { id = publisher.Id }, publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PublisherDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Publisher with id {id} not found.");

            existing.Name = dto.Name;
            existing.Website = dto.Website;

            await _publisherRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Publisher with id {id} not found.");

            await _publisherRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
