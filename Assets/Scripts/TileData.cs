using System;
using UnityEngine;

public struct TileData 
{
    public string Title { get; set; }
    public Vector2 Position { get; set; }
    public Vector2Int PositionRounded => Vector2Int.RoundToInt(Position);
    public Vector2 Size { get; set; }
}
