using UnityEngine;
using UnityEngine.Events;

class SimpleMenu : MonoBehaviour, IMenu
{
    Canvas canvas;
    
    public UnityEvent ViewOpened;
    public UnityEvent ViewClosed;


    public string Name => name;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Hide()
    {
        canvas.enabled = false;
        ViewClosed.Invoke();
    }

    public void Show()
    {
        canvas.enabled = true;
        ViewOpened.Invoke();
    }
}
