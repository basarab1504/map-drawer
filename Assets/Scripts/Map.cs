using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<TileData> tiles = new List<TileData>();
    private Vector2 leftBottom;
    private Vector2 rightTop;
    private IParser parser;

    public Vector2 LeftBottom => leftBottom;
    public Vector2 RightTop => rightTop;

    private void Awake()
    {
        parser = GetComponent<IParser>();
        GenerateMap();
    }

    public string FindTileName()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / 5.12f) * 5.12f);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / 5.12f) * 5.12f);

        return tiles.Find(x => x.PositionRounded == new Vector2Int(nearestX, nearestY)).Title;
    }

    private void GenerateMap()
    {
        GameObject parent = new GameObject();
        MapInfo info = parser.Parse();

        leftBottom = new Vector2(info.List[0].X, info.List[0].Y);
        rightTop = new Vector2(info.List[0].X, info.List[0].Y);

        foreach (var item in info.List)
        {
            if (leftBottom.x > item.X)
                leftBottom.x = item.X;
            else if (rightTop.x < item.X)
                rightTop.x = item.X;

            if (leftBottom.y > item.Y)
                leftBottom.y = item.Y;
            else if (rightTop.y < item.Y)
                rightTop.y = item.Y;

            var tile = Convert(item);

            var child = InstantiateTileObject(tile);
            child.transform.SetParent(parent.transform);

            tiles.Add(tile);
        }

        leftBottom -= new Vector2(info.List[0].Width / 2, info.List[0].Height / 2);
        rightTop += new Vector2(info.List[0].Width / 2, info.List[0].Height / 2);
    }

    private GameObject InstantiateTileObject(TileData tile)
    {
        GameObject gameObject = new GameObject();
        gameObject.name = tile.Title;
        gameObject.transform.position = tile.Position;
        var renderer = gameObject.AddComponent<SpriteRenderer>();
        var sprite = Resources.Load<Sprite>($"Sprites/Game/{tile.Title}");
        renderer.sprite = sprite;
        renderer.size = tile.Size;
        return gameObject;
    }

    private TileData Convert(MapInfo.Chunk chunk)
    {
        return new TileData()
        {
            Title = chunk.Id,
            Position = new Vector2(chunk.X, chunk.Y),
            Size = new Vector2(chunk.Width, chunk.Height)
        };
    }
}
