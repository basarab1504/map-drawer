using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Dictionary<Vector2Int, string> tiles = new Dictionary<Vector2Int, string>();

    public Vector2 min;
    public Vector2 max;

    public string FindTileName()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        int nearestX = Mathf.RoundToInt(Mathf.RoundToInt(pos.x / 5.12f) * 5.12f);
        int nearestY = Mathf.RoundToInt(Mathf.RoundToInt(pos.y / 5.12f) * 5.12f);

        return tiles[new Vector2Int(nearestX, nearestY)];
    }
}
