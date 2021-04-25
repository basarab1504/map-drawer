using UnityEngine;

public class TileFinder : MonoBehaviour
{
    [SerializeField] private Vector2 expectedTileSize;
    private Map map;

    private void Awake()
    {
        map = GetComponent<Map>();
    }

    public string FindTileName()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / expectedTileSize.x) * expectedTileSize.x);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / expectedTileSize.y) * expectedTileSize.y);

        return map.GetTileData(new Vector2Int(nearestX, nearestY)).Title;
    }
}
