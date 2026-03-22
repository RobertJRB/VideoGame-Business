namespace VideoGame.Infrastructure.Models
{
    public class PlatformModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public int LaunchYear { get; set; }
    }
}
