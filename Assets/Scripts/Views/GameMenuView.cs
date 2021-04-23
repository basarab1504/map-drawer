using UnityEngine;
using UnityEngine.UI;

class GameMenuView : SimpleMenu
{
    [SerializeField] private Text mapTile;

    public void SetTileText(string value)
    {
        mapTile.text = value;
    }
}
