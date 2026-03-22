using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Context;
using VideoGame.Infrastructure.Core;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.Infrastructure.Repositories
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(VideoGameContext context) : base(context) { }
    }
}
