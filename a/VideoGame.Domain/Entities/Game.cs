using VideoGame.Domain.Core;

namespace VideoGame.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
    }
}
