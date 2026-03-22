using VideoGame.Domain.Core;

namespace VideoGame.Domain.Entities
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int FoundedYear { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
