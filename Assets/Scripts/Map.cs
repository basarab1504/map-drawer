using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<TileData> tiles = new List<TileData>();
    private Vector2 leftBottom;
    private Vector2 rightTop;
    private IParser parser;
    private ITileFactory factory;

    public Vector2 LeftBottom => leftBottom;
    public Vector2 RightTop => rightTop;

    private void Awake()
    {
        parser = GetComponent<IParser>();
        factory = GetComponent<ITileFactory>();
        GenerateMap();
    }

    public TileData GetTileData(Vector2Int pos)
    {
        var index = tiles.BinarySearch(new TileData() { Position = pos }, new TileComparer());
        return tiles[index];
    }

    private void GenerateMap()
    {
        var data = parser.Parse();

        var firstItem = data[0];

        foreach (var item in data)
        {
            var child = factory.Instantiate(item);
            child.transform.SetParent(transform);

            tiles.Add(item);
        }

        tiles.Sort(new TileComparer());

        Vector2 halfSize = new Vector2(firstItem.Size.x / 2, firstItem.Size.y / 2);

        leftBottom = tiles[0].Position - halfSize;
        rightTop = tiles[tiles.Count - 1].Position + halfSize;
    }
}
