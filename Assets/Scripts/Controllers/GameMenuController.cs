using UnityEngine;

class GameMenuController : MonoBehaviour
{
    private GameMenuView view;

    [SerializeField] private MapParser parser;

    private void Awake()
    {
        view = GetComponent<GameMenuView>();
        view.ViewOpened.AddListener(() => OnMapTileChange(parser.FindTileName()));
    }

    public void OnMapTileChange(string value)
    {
        view.SetTileText(value);
    }
}
