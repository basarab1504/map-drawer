using UnityEngine;

public abstract class BaseParser : MonoBehaviour, IParser
{
    [SerializeField] private Vector2 expectedTileSize;

    public TileData[] Parse()
    {
        var parsed = InternalParse().List;
        TileData[] data = new TileData[parsed.Length];

        for (int i = 0; i < data.Length; i++)
        {
            var converted = Convert(parsed[i]);
            if (converted.Size != expectedTileSize)
                PosisitionFix(ref converted);
            data[i] = converted;
        }

        return data;
    }

    protected abstract MapInfo InternalParse();

    protected virtual TileData Convert(MapInfo.Chunk chunk)
    {
        return new TileData()
        {
            Title = chunk.Id,
            Position = new Vector2(chunk.X, chunk.Y),
            Size = new Vector2(chunk.Width, chunk.Height)
        };
    }

    protected virtual void PosisitionFix(ref TileData data)
    {
        data.Position -= (expectedTileSize / 2 - data.Size / 2);
    }
}
