using UnityEngine;

public interface ITileFactory
{
    GameObject Instantiate(TileData data);
}
