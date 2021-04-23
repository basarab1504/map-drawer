using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 2;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;
    [SerializeField] MapParser parser;

    private new Camera camera;
    private Vector3 pressedDownPoint;

    private void Start()
    {
        camera = GetComponent<Camera>();
        parser.min += new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
        parser.max -= new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
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
            var delta = Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime;
            var size = Mathf.Clamp(camera.orthographicSize + delta, minZoom, maxZoom);
            var diff = size - camera.orthographicSize;
            camera.orthographicSize = size;
            parser.min += new Vector2(diff, diff);
            parser.max -= new Vector2(diff, diff);
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, parser.min.x, parser.max.x), Mathf.Clamp(transform.position.y, parser.min.y, parser.max.y), transform.position.z);
    }
}
