using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Context;
using VideoGame.Infrastructure.Core;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.Infrastructure.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(VideoGameContext context) : base(context) { }
    }
}
