using VideoGame.Application.Contract;
using VideoGame.Application.Core;
using VideoGame.Application.Dtos.Developer;
using VideoGame.Infrastructure.Interfaces;
using VideoGame.Domain.Entities;

namespace VideoGame.Application.Service
{
    public class DeveloperService : BaseService<DeveloperDto, SaveDeveloperDto>, IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public override async Task<ServiceResult<List<DeveloperDto>>> GetAllAsync()
        {
            try
            {
                var developers = await _developerRepository.GetAllAsync();

                var developerDtos = developers.Select(d => new DeveloperDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    FoundedYear = d.FoundedYear
                }).ToList();

                return ServiceResult<List<DeveloperDto>>.Ok(developerDtos);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<DeveloperDto>>.Fail($"Error al obtener los desarrolladores: {ex.Message}");
            }
        }

        public override async Task<ServiceResult<DeveloperDto>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<DeveloperDto>.Fail("El ID debe ser mayor a 0.");

                var developer = await _developerRepository.GetByIdAsync(id);

                if (developer == null)
                    return ServiceResult<DeveloperDto>.Fail($"No se encontró el desarrollador con ID {id}.");

                var developerDto = new DeveloperDto
                {
                    Id = developer.Id,
                    Name = developer.Name,
                    Country = developer.Country,
                    FoundedYear = developer.FoundedYear
                };

                return ServiceResult<DeveloperDto>.Ok(developerDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<DeveloperDto>.Fail($"Error al obtener el desarrollador: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> SaveAsync(SaveDeveloperDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return ServiceResult.Fail("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Country))
                    return ServiceResult.Fail("El país es obligatorio.");

                if (dto.FoundedYear < 1800 || dto.FoundedYear > 2100)
                    return ServiceResult.Fail("El año de fundación debe estar entre 1800 y 2100.");

                var developer = new Developer
                {
                    Name = dto.Name,
                    Country = dto.Country,
                    FoundedYear = dto.FoundedYear
                };

                await _developerRepository.AddAsync(developer);
                return ServiceResult.Ok("Desarrollador creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al guardar el desarrollador: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> UpdateAsync(int id, SaveDeveloperDto dto)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult.Fail("El ID debe ser mayor a 0.");

                var existing = await _developerRepository.GetByIdAsync(id);
                if (existing == null)
                    return ServiceResult.Fail($"No se encontró el desarrollador con ID {id}.");

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return ServiceResult.Fail("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Country))
                    return ServiceResult.Fail("El país es obligatorio.");

                if (dto.FoundedYear < 1800 || dto.FoundedYear > 2100)
                    return ServiceResult.Fail("El año de fundación debe estar entre 1800 y 2100.");

                existing.Name = dto.Name;
                existing.Country = dto.Country;
                existing.FoundedYear = dto.FoundedYear;

                await _developerRepository.UpdateAsync(existing);
                return ServiceResult.Ok("Desarrollador actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al actualizar el desarrollador: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult.Fail("El ID debe ser mayor a 0.");

                var existing = await _developerRepository.GetByIdAsync(id);
                if (existing == null)
                    return ServiceResult.Fail($"No se encontró el desarrollador con ID {id}.");

                await _developerRepository.DeleteAsync(id);
                return ServiceResult.Ok("Desarrollador eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al eliminar el desarrollador: {ex.Message}");
            }
        }
    }
}
