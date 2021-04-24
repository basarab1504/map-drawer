using System.Collections.Generic;
using UnityEngine;

public class MapParser : MonoBehaviour
{
    [SerializeField] private TextAsset mapConfig;
    private Dictionary<Vector2Int, string> tiles = new Dictionary<Vector2Int, string>();

    public Vector2 min;
    public Vector2 max;

    private void Awake()
    {
        GenerateMap(ParseMap(mapConfig.text));
    }

    public string FindTileName()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / 5.12f) * 5.12f);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / 5.12f) * 5.12f);

        return tiles[new Vector2Int(nearestX, nearestY)];
    }

    private MapInfo ParseMap(string json)
    {
        return JsonUtility.FromJson<MapInfo>(json);
    }

    private void GenerateMap(MapInfo map)
    {
        min = new Vector2(map.List[0].X, map.List[0].Y);
        max = new Vector2(map.List[0].X, map.List[0].Y);

        foreach (var item in map.List)
        {
            if (min.x > item.X)
                min.x = item.X;
            else if (max.x < item.X)
                max.x = item.X;

            if (min.y > item.Y)
                min.y = item.Y;
            else if (max.y < item.Y)
                max.y = item.Y;
                
            GameObject gameObject = new GameObject();
            gameObject.transform.position = new Vector2(item.X, item.Y);
            // gameObject.transform.localScale = new Vector2(item.Width, item.Height);
            var sprite = Resources.Load<Sprite>($"Sprites/Game/{item.Id}");
            var renderer = gameObject.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.size = new Vector2(item.Width, item.Height);
            tiles.Add(Vector2Int.RoundToInt(gameObject.transform.position), sprite.name);
        }

        min -= new Vector2(map.List[0].Width / 2, map.List[0].Height / 2);
        max += new Vector2(map.List[0].Width / 2, map.List[0].Height / 2);
    }
}
