using GamesAsArt.Domain.Common;

namespace GamesAsArt.Domain.Entities;
public class Image : BaseEntity
{
    public required string Url { get; set; } = string.Empty;
    public int GameId { get; set; }

    public required Game Game { get; set; }
}
