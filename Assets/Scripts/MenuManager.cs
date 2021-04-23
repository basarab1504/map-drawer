using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Dictionary<string, IMenu> screens = new Dictionary<string, IMenu>();
    private IMenu openedMenu;

    private void Awake()
    {
        var canvases = GetComponentsInChildren<IMenu>();
        foreach (var item in canvases)
        {
            screens.Add(item.Name, item);
        }
    }

    public void Show(string name)
    {
        if (screens.ContainsKey(name))
        {
            openedMenu?.Hide();

            IMenu menu = screens[name];
            openedMenu = menu;

            menu.Show();
        }
    }
}
