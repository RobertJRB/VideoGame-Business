using VideoGame.Domain.Entities;
using VideoGame.Infrastructure.Context;
using VideoGame.Infrastructure.Core;
using VideoGame.Infrastructure.Interfaces;

namespace VideoGame.Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(VideoGameContext context) : base(context) { }
    }
}
