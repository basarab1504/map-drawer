using UnityEngine;

public abstract class BaseParser : MonoBehaviour, IParser
{
    public abstract TileData[] Parse();

    protected TileData Convert(MapInfo.Chunk chunk)
    {
        return new TileData()
        {
            Title = chunk.Id,
            Position = new Vector2(chunk.X, chunk.Y),
            Size = new Vector2(chunk.Width, chunk.Height)
        };
    }
}
