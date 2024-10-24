using GamesAsArt.Domain.Common;

namespace GamesAsArt.Domain.Entities;
public class Tag : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Game> Games { get; } = new List<Game>();
}
