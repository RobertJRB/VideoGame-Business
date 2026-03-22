using VideoGame.Application.Dtos;

namespace VideoGame.Application.Dtos.Game
{
    public class GameDto : DtoBase
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
    }
}
