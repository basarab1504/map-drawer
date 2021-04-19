
using System.Collections.Generic;
using UnityEngine;

public class MapParser : MonoBehaviour
{
    [SerializeField] private TextAsset mapConfigJson;
    private Dictionary<Vector2, string> tiles = new Dictionary<Vector2, string>();

    private void Start()
    {
        GenerateMap(ParseMap(mapConfigJson.text));
    }

    public void Find()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        var val = Mathf.RoundToInt(pos.x / 5.12f) * 5.12f;
        var val2 = Mathf.RoundToInt(pos.y / 5.12f) * 5.12f;
        Vector2 v = new Vector2(val, val2);

        Debug.Log(tiles[v]);
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
            tiles.Add(gameObject.transform.position, sprite.name);
        }
    }
}
