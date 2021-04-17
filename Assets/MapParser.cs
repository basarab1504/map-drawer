
using UnityEngine;

public class MapParser : MonoBehaviour
{
    [SerializeField] private TextAsset mapConfigJson;

    private void Start()
    {
        GenerateMap(ParseMap(mapConfigJson.text));
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
            gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Sprites/Game/{item.Id}");
        }
    }
}
