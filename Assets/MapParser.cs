
using UnityEngine;

public class MapParser : MonoBehaviour
{
    public TextAsset json;
    private void Start()
    {
        ParseAndSpawn(json.text);
    }

    public void ParseAndSpawn(string json)
    {
        var infos = JsonUtility.FromJson<Infos>(json);

        foreach (var item in infos.List)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = new Vector2(item.X, item.Y);
            gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Sprites/Game/{item.Id}");
        }
    }
}
