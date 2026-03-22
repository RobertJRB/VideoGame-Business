using VideoGame.Domain.Entities;
using VideoGame.Domain.Repository;

namespace VideoGame.Infrastructure.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetByDeveloperIdAsync(int developerId);
    }
}
