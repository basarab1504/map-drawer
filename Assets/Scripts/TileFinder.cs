using UnityEngine;

public class TileFinder : MonoBehaviour
{
    private Map map;

    private void Awake()
    {
        map = GetComponent<Map>();
    }

    public string FindTileName()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / 5.12f) * 5.12f);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / 5.12f) * 5.12f);

        return map.GetTileData(new Vector2Int(nearestX, nearestY)).Title;
    }
}
