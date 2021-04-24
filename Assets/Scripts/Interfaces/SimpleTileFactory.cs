using UnityEngine;

public class SimpleTileFactory : MonoBehaviour, ITileFactory
{
    public GameObject Instantiate(TileData tile)
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
}
