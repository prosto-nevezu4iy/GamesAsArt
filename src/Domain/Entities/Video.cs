using GamesAsArt.Domain.Common;

namespace GamesAsArt.Domain.Entities;
public class Video : BaseEntity
{
    public required string Url { get; set; }
    public int GameId { get; set; }
    public required Game Game { get; set; }
}
