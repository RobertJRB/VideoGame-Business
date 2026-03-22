using VideoGame.Application.Dtos;

namespace VideoGame.Application.Dtos.Developer
{
    public class DeveloperDto : DtoBase
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int FoundedYear { get; set; }
    }
}
