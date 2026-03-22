namespace VideoGame.Infrastructure.Models
{
    public class DeveloperModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int FoundedYear { get; set; }
    }
}
