using UnityEngine;

public class Zoomer : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;

    public void Update()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            var size = Mathf.Clamp(Camera.main.orthographicSize + Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            Camera.main.orthographicSize = size;
        }
    }
}
