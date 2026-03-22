using Microsoft.EntityFrameworkCore;
using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Context;
using VideoGame.Infrastructure.Core;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly VideoGameContext _context;

        public GameRepository(VideoGameContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetByDeveloperIdAsync(int developerId)
            => await _dbSet.Where(g => g.DeveloperId == developerId).ToListAsync();
    }
}
