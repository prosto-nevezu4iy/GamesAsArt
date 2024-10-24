using GamesAsArt.Domain.Common;

namespace GamesAsArt.Domain.Entities;
public class Game : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Release { get; set; }
    public int AverageScore { get; set; }

    public ICollection<Image> Images { get; } = new List<Image>();
    public ICollection<Video> Videos { get; } = new List<Video>();
    public ICollection<Tag> Tags { get; } = new List<Tag>();
}
