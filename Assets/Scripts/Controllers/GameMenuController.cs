using UnityEngine;

class GameMenuController : MonoBehaviour
{
    private GameMenuView view;

    [SerializeField] private TileFinder finder;

    private void Awake()
    {
        view = GetComponent<GameMenuView>();
        view.ViewOpened.AddListener(() => OnMapTileChange(finder.FindTileName()));
    }

    public void OnMapTileChange(string value)
    {
        view.SetTileText(value);
    }
}
