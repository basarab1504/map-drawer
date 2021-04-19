using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapParser : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] private TextAsset mapConfigJson;
    private Dictionary<Vector2Int, string> tiles = new Dictionary<Vector2Int, string>();

    private void Start()
    {
        GenerateMap(ParseMap(mapConfigJson.text));
    }

    public void Find()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / 5.12f) * 5.12f);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / 5.12f) * 5.12f);

        text.text = tiles[new Vector2Int(nearestX, nearestY)];
    }

    public Map ParseMap(string json)
    {
        return JsonUtility.FromJson<Map>(json);
    }

    private void GenerateMap(Map map)
    {
        foreach (var item in map.List)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = new Vector2(item.X, item.Y);
            // gameObject.transform.localScale = new Vector2(item.Width, item.Height);
            var sprite = Resources.Load<Sprite>($"Sprites/Game/{item.Id}");
            gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
            tiles.Add(Vector2Int.RoundToInt(gameObject.transform.position), sprite.name);
        }
    }
}
