using UnityEngine;

public class SimpleTileFactory : MonoBehaviour, ITileFactory
{
    public GameObject Instantiate(TileData tile)
    {
        GameObject gameObject = new GameObject();
        gameObject.name = tile.Title;
        gameObject.transform.position = tile.Position;

        if (tile.Position.x >= 40.0f)
        {
            Debug.Log(gameObject.transform.position + " " + (Vector3)gameObject.transform.position);
        }
        var renderer = gameObject.AddComponent<SpriteRenderer>();
        var sprite = Resources.Load<Sprite>($"Sprites/Game/{tile.Title}");
        renderer.sprite = sprite;
        renderer.size = tile.Size;
        return gameObject;
    }
}
