using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 2;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;

    private new Camera camera;
    private Vector3 pressedDownPoint;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateZoom();
        UpdateDrag();
    }

    private void UpdateZoom()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            var size = Mathf.Clamp(camera.orthographicSize + Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            camera.orthographicSize = size;
        }
    }

    private void UpdateDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedDownPoint = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector3 viewportPoint = camera.ScreenToViewportPoint(Input.mousePosition - pressedDownPoint);
        Vector3 targetPosition = new Vector3(viewportPoint.x * dragSpeed, viewportPoint.y * dragSpeed, 0);
        transform.position += targetPosition * Time.deltaTime;
    }
}
