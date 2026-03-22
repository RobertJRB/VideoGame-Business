using VideoGame.Application.Contract;
using VideoGame.Application.Core;
using VideoGame.Application.Dtos.Game;
using VideoGame.Infrastructure.Interfaces;
using VideoGame.Domain.Entities;

namespace VideoGame.Application.Service
{
    public class GameService : BaseService<GameDto, SaveGameDto>, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public override async Task<ServiceResult<List<GameDto>>> GetAllAsync()
        {
            try
            {
                var games = await _gameRepository.GetAllAsync();

                var gameDtos = games.Select(g => new GameDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Genre = g.Genre,
                    ReleaseDate = g.ReleaseDate,
                    Price = g.Price,
                    DeveloperId = g.DeveloperId,
                    PublisherId = g.PublisherId
                }).ToList();

                return ServiceResult<List<GameDto>>.Ok(gameDtos);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<GameDto>>.Fail($"Error al obtener los juegos: {ex.Message}");
            }
        }

        public override async Task<ServiceResult<GameDto>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<GameDto>.Fail("El ID debe ser mayor a 0.");

                var game = await _gameRepository.GetByIdAsync(id);

                if (game == null)
                    return ServiceResult<GameDto>.Fail($"No se encontró el juego con ID {id}.");

                var gameDto = new GameDto
                {
                    Id = game.Id,
                    Title = game.Title,
                    Genre = game.Genre,
                    ReleaseDate = game.ReleaseDate,
                    Price = game.Price,
                    DeveloperId = game.DeveloperId,
                    PublisherId = game.PublisherId
                };

                return ServiceResult<GameDto>.Ok(gameDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<GameDto>.Fail($"Error al obtener el juego: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> SaveAsync(SaveGameDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                    return ServiceResult.Fail("El título es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Genre))
                    return ServiceResult.Fail("El género es obligatorio.");

                if (dto.Price <= 0)
                    return ServiceResult.Fail("El precio debe ser mayor a 0.");

                if (dto.DeveloperId <= 0)
                    return ServiceResult.Fail("Debe seleccionar un desarrollador válido.");

                if (dto.PublisherId <= 0)
                    return ServiceResult.Fail("Debe seleccionar un publisher válido.");

                var game = new Game
                {
                    Title = dto.Title,
                    Genre = dto.Genre,
                    ReleaseDate = dto.ReleaseDate,
                    Price = dto.Price,
                    DeveloperId = dto.DeveloperId,
                    PublisherId = dto.PublisherId
                };

                await _gameRepository.AddAsync(game);
                return ServiceResult.Ok("Juego creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al guardar el juego: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> UpdateAsync(int id, SaveGameDto dto)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult.Fail("El ID debe ser mayor a 0.");

                var existing = await _gameRepository.GetByIdAsync(id);
                if (existing == null)
                    return ServiceResult.Fail($"No se encontró el juego con ID {id}.");

                if (string.IsNullOrWhiteSpace(dto.Title))
                    return ServiceResult.Fail("El título es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Genre))
                    return ServiceResult.Fail("El género es obligatorio.");

                if (dto.Price <= 0)
                    return ServiceResult.Fail("El precio debe ser mayor a 0.");

                if (dto.DeveloperId <= 0)
                    return ServiceResult.Fail("Debe seleccionar un desarrollador válido.");

                if (dto.PublisherId <= 0)
                    return ServiceResult.Fail("Debe seleccionar un publisher válido.");

                existing.Title = dto.Title;
                existing.Genre = dto.Genre;
                existing.ReleaseDate = dto.ReleaseDate;
                existing.Price = dto.Price;
                existing.DeveloperId = dto.DeveloperId;
                existing.PublisherId = dto.PublisherId;

                await _gameRepository.UpdateAsync(existing);
                return ServiceResult.Ok("Juego actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al actualizar el juego: {ex.Message}");
            }
        }

        public override async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult.Fail("El ID debe ser mayor a 0.");

                var existing = await _gameRepository.GetByIdAsync(id);
                if (existing == null)
                    return ServiceResult.Fail($"No se encontró el juego con ID {id}.");

                await _gameRepository.DeleteAsync(id);
                return ServiceResult.Ok("Juego eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"Error al eliminar el juego: {ex.Message}");
            }
        }
    }
}
