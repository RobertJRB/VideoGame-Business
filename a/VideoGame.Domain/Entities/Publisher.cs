using VideoGame.Domain.Core;

namespace VideoGame.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
