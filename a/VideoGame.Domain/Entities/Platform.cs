using VideoGame.Domain.Core;

namespace VideoGame.Domain.Entities
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public int LaunchYear { get; set; }
    }
}
