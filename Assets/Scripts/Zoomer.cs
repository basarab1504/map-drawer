using UnityEngine;

public class Zoomer : MonoBehaviour
{
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;

    public void Update()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            var size = Mathf.Clamp(camera.orthographicSize + Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            camera.orthographicSize = size;
        }
    }
}
