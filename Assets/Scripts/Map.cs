using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<TileData> tiles = new List<TileData>();
    private Vector2 leftBottom;
    private Vector2 rightTop;
    private IParser parser;
    private ITileFactory factory;

    public IReadOnlyList<TileData> Tiles => tiles;
    public Vector2 LeftBottom => leftBottom;
    public Vector2 RightTop => rightTop;

    private void Awake()
    {
        parser = GetComponent<IParser>();
        factory = GetComponent<ITileFactory>();
        GenerateMap();
    }



    private void GenerateMap()
    {
        var data = parser.Parse();

        var firstItem = data[0];

        leftBottom = firstItem.Position;
        rightTop = firstItem.Position;

        foreach (var item in data)
        {
            if (leftBottom.x > item.Position.x)
                leftBottom.x = item.Position.x;
            else if (rightTop.x < item.Position.x)
                rightTop.x = item.Position.x;

            if (leftBottom.y > item.Position.y)
                leftBottom.y = item.Position.y;
            else if (rightTop.y < item.Position.y)
                rightTop.y = item.Position.y;

            var child = factory.Instantiate(item);
            child.transform.SetParent(transform);

            tiles.Add(item);
        }

        Vector2 halfSize = new Vector2(firstItem.Size.x / 2, firstItem.Size.y / 2);

        leftBottom -= halfSize;
        rightTop += halfSize;
    }
}
