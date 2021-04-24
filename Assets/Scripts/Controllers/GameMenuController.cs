using UnityEngine;

class GameMenuController : MonoBehaviour
{
    private GameMenuView view;

    [SerializeField] private Map map;

    private void Awake()
    {
        view = GetComponent<GameMenuView>();
        view.ViewOpened.AddListener(() => OnMapTileChange(map.FindTileName()));
    }

    public void OnMapTileChange(string value)
    {
        view.SetTileText(value);
    }
}
