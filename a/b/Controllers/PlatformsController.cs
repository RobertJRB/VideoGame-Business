using Microsoft.AspNetCore.Mvc;
using VideoGame.API.DTOs;
using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformsController(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var platforms = await _platformRepository.GetAllAsync();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var platform = await _platformRepository.GetByIdAsync(id);
            if (platform == null)
                return NotFound($"Platform with id {id} not found.");

            return Ok(platform);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlatformDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var platform = new Platform
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                LaunchYear = dto.LaunchYear
            };

            await _platformRepository.AddAsync(platform);
            return CreatedAtAction(nameof(GetById), new { id = platform.Id }, platform);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlatformDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _platformRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Platform with id {id} not found.");

            existing.Name = dto.Name;
            existing.Manufacturer = dto.Manufacturer;
            existing.LaunchYear = dto.LaunchYear;

            await _platformRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _platformRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Platform with id {id} not found.");

            await _platformRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
