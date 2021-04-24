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

    Vector2 boundsMin;
    Vector2 boundsMax;

    Vector2 center = new Vector2(17.92f, -5.12f);

    private void Awake()
    {
        camera = GetComponent<Camera>();
        AdjustCamera();
    }

    private void Start()
    {
        boundsMin = parser.min + new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
        boundsMax = parser.max - new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
    }

    private void Update()
    {
        UpdateZoom();
        UpdateDrag();
    }

    private void AdjustCamera()
    {
        Camera.main.transform.position = new Vector3(
            (Mathf.Abs(parser.max.x) - Mathf.Abs(parser.min.x)) / 2,
            (Mathf.Abs(parser.max.y) - Mathf.Abs(parser.min.y)) / 2,
            Camera.main.transform.position.z);
        var diff = Mathf.Abs(parser.max.y - parser.min.y);
        Camera.main.orthographicSize = Mathf.Clamp(diff / 2, minZoom, maxZoom);
    }

    private void UpdateZoom()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            var delta = Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime;
            var size = Mathf.Clamp(camera.orthographicSize + delta, minZoom, maxZoom);
            var diff = size - camera.orthographicSize;
            camera.orthographicSize = size;
            boundsMin += new Vector2(diff, diff);
            boundsMax -= new Vector2(diff, diff);
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x), Mathf.Clamp(transform.position.y, boundsMin.y, boundsMax.y), transform.position.z);
    }
}
